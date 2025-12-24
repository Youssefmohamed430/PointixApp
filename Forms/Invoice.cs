using FontAwesome.Sharp;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using PointixApp.Factories;
using PointixApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using Document = iText.Layout.Document;
using Color = System.Drawing.Color;
using iText.IO.Font;
using iText.Kernel.Font;
using PointixApp.Patterns;
using iText.Commons.Actions.Contexts;
using Org.BouncyCastle.Crypto.Utilities;

namespace PointixApp.Forms
{
    public partial class Invoice : Form
    {
        private readonly AuthModel authModel;
        private Mediator mediator;
        private readonly AppDbContext context;
        private double totalamount;
        private Dictionary<Product, int> saleitems = new Dictionary<Product, int>();
        private Panel productsPanel;
        private int cardHeight = 80;
        private int cardMargin = 10;
        private string name = "";
        private int CustomerId = 0;
        private string Customerphone = "";
        private bool isButtonClicked = false;
        private string lastBuiltLanguage = "";
        public Invoice()
        {
            InitializeComponent();
        }
        public Invoice(AuthModel _authModel, AppDbContext _context)
        {
            ManageLanguages.EquipLanguage(this);
            InitializeComponent();
            this.authModel = _authModel;
            this.context = _context;
            this.mediator = new Mediator(context, authModel);
            var menu = new Menu(authModel, context, ManageLanguages.Language);
            menu.Dock = DockStyle.Left;
            this.Controls.Add(menu);
        }
        private void Invoice_Load(object sender, EventArgs e)
        {
            

            // إزالة جميع الأحداث المسجلة مسبقاً
            dataGridView1.CellClick -= DataGridView1_CellContentClick;

            // استخدام CellContentClick مع التحقق الإضافي
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }
        /* ------------------ IconButtons --------------------- */
        private void iconButton11_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            if (ManageLanguages.Language == "en")
            {
                if (keyword == "Search by Product Name" || string.IsNullOrWhiteSpace(keyword))
                {
                    MessageBox.Show("Please enter a valid product name to search.");
                    return;
                }
            }
            else
            {
                if (keyword == "ابحث باسم المنتج" || string.IsNullOrWhiteSpace(keyword))
                {
                    MessageBox.Show("الرجاء إدخال اسم المنتج صالحًا للبحث.");
                    return;
                }
            }
            var products = mediator.InventoryService.SearchForProduct(keyword);
            RefreshDataGridView(products);
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            NotificationPanel.Visible = !NotificationPanel.Visible;

            if (NotificationPanel.Visible)
            {
                this.LoadNotifications(mediator, NotificationPanel, authModel.Id, mediator.NotificationService);
            }
        }
        /* ------------------ DataGridView Methods ---------------*/
        public void RefreshDataGridView(IQueryable<Product> products)
        {
            EnsureDataGridViewColumnsBuilt();
            dataGridView1.Rows.Clear();
            FillData(products);
        }
        private void FillData(IQueryable<Product> products)
        {
            foreach (var product in products)
            {
                dataGridView1.Rows
                    .Add(product.ProductId, product.ProductName, product.Price);
            }
        }
        private void CreateCloumnsEnglish()
        {
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("name", "Product Name");
            dataGridView1.Columns.Add("price", "Price");

            DataGridViewButtonColumn AddButtonColumn = new DataGridViewButtonColumn();
            AddButtonColumn.Name = "Add";
            AddButtonColumn.HeaderText = "Add";
            AddButtonColumn.Text = "+ Add";
            AddButtonColumn.UseColumnTextForButtonValue = true;
            AddButtonColumn.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(AddButtonColumn);
        }

        private void EnsureDataGridViewColumnsBuilt()
        {
            if (lastBuiltLanguage != ManageLanguages.Language)
            {
                if (ManageLanguages.Language == "en")
                    CreateCloumnsEnglish();
                else
                    CreateCloumnsArabic();

                lastBuiltLanguage = ManageLanguages.Language;
            }
        }

        private void CreateCloumnsArabic()
        {

            dataGridView1.Columns.Add("id", "معرف المنتج");
            dataGridView1.Columns.Add("name", "الاسم");
            dataGridView1.Columns.Add("price", "السعر");

            DataGridViewButtonColumn AddButtonColumn = new DataGridViewButtonColumn();
            AddButtonColumn.Name = "Add";
            AddButtonColumn.HeaderText = "اضافة";
            AddButtonColumn.Text = "+ اضافة";
            AddButtonColumn.UseColumnTextForButtonValue = true;
            AddButtonColumn.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(AddButtonColumn);
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender != dataGridView1) return;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (columnName == "Add")
                {
                    var selectedRow = dataGridView1.Rows[e.RowIndex];

                    int productid = Convert.ToInt32(selectedRow.Cells["id"].Value);

                    DialogResult result;
                    string productName = selectedRow.Cells["name"].Value.ToString();
                    if (ManageLanguages.Language == "en")
                        result = MessageBox.Show($"Are you sure you want to Add {productName}?", "Confirm Add", MessageBoxButtons.YesNo);
                    else
                        result = MessageBox.Show($"هل أنت متأكد من اضافة ?{productName}", "تأكيد الاضافة", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                        HandleAddingAction(productid);
                }
            }
        }
        private void HandleAddingAction(int productid)
        {
            try
            {
                if (productid <= 0)
                    throw new ArgumentException("Invalid product ID.");

                var product = context.Products.FirstOrDefault(p => p.ProductId == productid);

                if (product != null)
                {
                    if (product.Quantity == 0)
                    {
                        if (ManageLanguages.Language == "en")
                            MessageBox.Show("Product is out of stock");
                        else
                            MessageBox.Show("تم انتهاء المنتج");
                        return;
                    }

                    if (ItemsPanel.Controls[0] is Label) ItemsPanel.Controls.Clear();
                    var card = CreateProductCard(product);
                    ItemsPanel.Controls.Add(card);
                }
                else
                {
                    if (ManageLanguages.Language == "ar")
                        MessageBox.Show("فشل في الاضافة");
                    else
                        MessageBox.Show("Failed to Add");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Error", ex);
            }
        }
        /* ------------------ Invoice Methods ------------------*/
        private Panel CreateProductCard(Product product)
        {
            Panel card = new Panel();
            card.Size = new Size(ItemsPanel.Width - 20, cardHeight);
            card.BackColor = Color.WhiteSmoke;
            card.Margin = new Padding(5);
            card.BorderStyle = BorderStyle.None;


            int yOffset = 0;
            if (ItemsPanel.Controls.Count > 0)
            {
                var lastCard = ItemsPanel.Controls[ItemsPanel.Controls.Count - 1] as Control;
                yOffset = lastCard.Bottom + 5; // مسافة بسيطة بين الكروت
            }
            card.Location = new Point(0, yOffset);

            // اسم المنتج
            Label productNameLabel = new Label();
            productNameLabel.Text = product.ProductName;
            productNameLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            productNameLabel.ForeColor = Color.FromArgb(64, 64, 64);
            productNameLabel.Location = new Point(10, 10);
            productNameLabel.Size = new Size(120, 20);
            card.Controls.Add(productNameLabel);

            // سعر المنتج
            Label priceLabel = new Label();
            priceLabel.Text = $"${product.Price:F2}";
            priceLabel.Font = new Font("Arial", 9);
            priceLabel.ForeColor = Color.FromArgb(100, 100, 100);
            priceLabel.Location = new Point(10, 35);
            priceLabel.Size = new Size(80, 15);
            card.Controls.Add(priceLabel);

            // DomainUpDown للكمية
            DomainUpDown quantityUpDown = new DomainUpDown();
            quantityUpDown.Location = new Point(card.Width - 250, 15);
            quantityUpDown.Size = new Size(50, 25);
            quantityUpDown.ReadOnly = true;
            quantityUpDown.InterceptArrowKeys = false;

            // إضافة الأرقام للـ DomainUpDown
            for (int i = 1; i <= product.Quantity; i++)
            {
                quantityUpDown.Items.Add(i.ToString());
            }

            quantityUpDown.SelectedItem = quantityUpDown.Items[0];

            card.Controls.Add(quantityUpDown);


            // زر التأكيد
            IconButton ConfirmButton = new IconButton();
            ConfirmButton.IconChar = IconChar.CheckSquare;
            ConfirmButton.IconColor = Color.Green;
            ConfirmButton.IconSize = 30;
            ConfirmButton.Size = new Size(40, 30);
            ConfirmButton.Location = new Point(card.Width - 90, 20);
            ConfirmButton.BackColor = Color.Transparent;
            ConfirmButton.FlatStyle = FlatStyle.Flat;
            ConfirmButton.FlatAppearance.BorderSize = 0;
            ConfirmButton.Cursor = Cursors.Hand;

            ConfirmButton.Click += (sender, e) =>
            {
                if (!saleitems.ContainsKey(product))
                {
                    int selectedQuantity = Convert.ToInt32(quantityUpDown.SelectedItem.ToString());
                    saleitems.Add(product, selectedQuantity);

                    // تحديث المبلغ الكلي
                    totalamount = saleitems.Select(s => s.Key.Price * s.Value).Sum();
                    this.totallabel.Text = $"${totalamount:F2}";

                    // إخفاء أو تعطيل الـ card بعد الإضافة
                    card.BackColor = Color.LightGray;
                    ConfirmButton.Enabled = false;
                    quantityUpDown.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Product already added to invoice!");
                    ItemsPanel.Controls.Remove(card);
                    RearrangeCards();
                }
            };

            card.Controls.Add(ConfirmButton);

            // زر الحذف
            IconButton deleteButton = new IconButton();
            deleteButton.IconChar = IconChar.Trash;
            deleteButton.IconColor = Color.Red;
            deleteButton.IconSize = 20;
            deleteButton.Size = new Size(30, 30);
            deleteButton.Location = new Point(card.Width - 50, 20);
            deleteButton.BackColor = Color.Transparent;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Cursor = Cursors.Hand;

            deleteButton.Click += (sender, e) =>
            {
                var result = MessageBox.Show($"Are you sure you want to remove {product.ProductName}?",
                "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // إزالة الـ card من الـ panel
                    ItemsPanel.Controls.Remove(card);

                    if (ItemsPanel.Controls.Count == 0)
                        ItemsPanel.Controls.Add(label8);

                    // إزالة من saleitems إذا كان موجود
                    if (saleitems.ContainsKey(product))
                    {
                        saleitems.Remove(product);

                        // تحديث المبلغ الكلي
                        totalamount = saleitems.Select(s => s.Key.Price * s.Value).Sum();
                        this.totallabel.Text = $"${totalamount:F2}";
                    }

                    // إعادة ترتيب الـ cards المتبقية
                    RearrangeCards();
                }
            };

            card.Controls.Add(deleteButton);


            // scroll للأسفل إذا لزم الأمر
            ItemsPanel.ScrollControlIntoView(card);

            // إضافة الـ card للـ panel
            return card;
        }
        private void RearrangeCards()
        {
            int yOffset = 0;

            var cards = ItemsPanel.Controls
                .OfType<Panel>()
                .OrderBy(c => c.Location.Y)
                .ToList();

            foreach (Panel card in cards)
            {
                card.Size = new Size(ItemsPanel.ClientSize.Width - 20, card.Height);
                card.Location = new Point(0, yOffset);
                yOffset += card.Height + 5;
            }
        }
        private void ClearControlsEnglish()
        {
            CustomerName.Text = "Customer Name";
            CustomerName.ReadOnly = false;
            CustomerName.ForeColor = Color.LightGray;
            CustomerPhone.Text = "Customer Phone";
            CustomerPhone.ForeColor = Color.LightGray;
            CustomerPhone.ReadOnly = false;
            CustomerName.ForeColor = Color.LightGray;
            PaidAmount.Text = "Paid Amount";
            PaidAmount.ForeColor = Color.LightGray;
            CustomerName.ForeColor = Color.LightGray;
            isButtonClicked = false;
            name = "";
            Customerphone = "";
            totallabel.Text = "$0.00";
            ItemsPanel.Controls.Clear();
            ItemsPanel.Controls.Add(label8);
            dataGridView1.Rows.Clear();
            this.textBox1.Text = "Search by Product Name";
            this.textBox1.ForeColor = Color.LightGray;
            this.CustomerName.Text = "Customer Name";
            NotesTextBox.Text = "Notes";
            NotesTextBox.ForeColor = Color.LightGray;
            saleitems.Clear();
        }
        private void ClearControlsArabic()
        {
            CustomerName.Text = "اسم العميل";
            CustomerName.ReadOnly = false;
            CustomerName.ForeColor = Color.LightGray;
            CustomerPhone.Text = "رقم العميل";
            CustomerPhone.ForeColor = Color.LightGray;
            CustomerPhone.ReadOnly = false;
            CustomerName.ForeColor = Color.LightGray;
            PaidAmount.Text = "الكمية المدفوعة";
            PaidAmount.ForeColor = Color.LightGray;
            CustomerName.ForeColor = Color.LightGray;
            isButtonClicked = false;
            name = "";
            Customerphone = "";
            totallabel.Text = "$0.00";
            ItemsPanel.Controls.Clear();
            ItemsPanel.Controls.Add(label8);
            dataGridView1.Rows.Clear();
            this.textBox1.Text = "البحث باسم المنتج";
            this.textBox1.ForeColor = Color.LightGray;
            saleitems.Clear();
            NotesTextBox.Text = "ملاحظات";
            NotesTextBox.ForeColor = Color.LightGray;
        }

        /* ----------------------------------------------------- */
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxClick(textBox1, "Search by Product Name");
            else
                this.TextBoxClick(textBox1, "ابحث باسم المنتج");
        }
        private void CustomerName_Click(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxClick(CustomerName, "Customer Name");
            else
                this.TextBoxClick(CustomerName, "اسم العميل");
        }
        private void CustomerName_Leave(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxLeave(CustomerName, "Customer Name");
            else
                this.TextBoxLeave(CustomerName, "اسم العميل");
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxLeave(textBox1, "Search by Product Name");
            else
                this.TextBoxLeave(textBox1, "ابحث باسم المنتج");
        }
        private void CustomerPhone_Click(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxClick(CustomerPhone, "Customer Phone");
            else
                this.TextBoxClick(CustomerPhone, "رقم العميل");
        }
        private void CustomerPhone_Leave(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxLeave(CustomerPhone, "Customer Phone");
            else
                this.TextBoxLeave(CustomerPhone, "رقم العميل");
        }
        private void PaidAmount_Click(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxClick(PaidAmount, "Paid Amount");
            else
                this.TextBoxClick(PaidAmount, "الكمية المدفوعة");
        }
        private void NotesTextBox_Click(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxClick(NotesTextBox, "Notes");
            else
                this.TextBoxClick(NotesTextBox, "ملاحظات");
        }
        private void PaidAmount_Leave(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxLeave(PaidAmount, "Paid Amount");
            else
                this.TextBoxLeave(PaidAmount, "الكمية المدفوعة");
        }
        private void NotesTextBox_Leave(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxLeave(NotesTextBox, "Notes");
            else
                this.TextBoxLeave(NotesTextBox, "ملاحظات");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task<Exception> error = null;
            try
            {
                if (!isButtonClicked)
                {
                    if (ManageLanguages.Language == "en")
                        MessageBox.Show("Please Enter Information Of Customer");
                    else
                        MessageBox.Show("الرجاء إدخال معلومات العميل ");
                    return;
                }
                else
                {
                    if (NotesTextBox.Text == "Notes" || string.IsNullOrWhiteSpace(NotesTextBox.Text))
                        NotesTextBox.Text = "";
                    error = mediator.SaleService.AddSale(name, Customerphone, authModel.Id, saleitems, Convert.ToDecimal(totalamount), Convert.ToDecimal(PaidAmount.Text), NotesTextBox.Text);
                }

                if (error != null)
                    ExceptionHandler.ShowSuccess("Success", "Sale is adding success");
                else
                    ExceptionHandler.ShowError("Error", error.Result);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Adding Sale", ex);
            }
        }
        private void GenerateInvoicePdf()
        {
            string dest = "";
            DeterminePlaceToSave(ref dest);

            if (string.IsNullOrWhiteSpace(dest)) return;

            using var writer = new PdfWriter(dest);
            using var pdf = new PdfDocument(writer);
            var doc = new Document(pdf);

            var font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            doc.SetFont(font);
            doc.SetFontColor(ColorConstants.BLACK);

            var title = new Paragraph("INVOICE")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(24)
                .SetMarginBottom(20);
            doc.Add(title);

            var PharmacyName = new Paragraph("PharmacyName")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(10)
                .SetMarginBottom(20);
            doc.Add(PharmacyName);

            doc.Add(new Paragraph("Date: " + DateTime.Now.ToString("yyyy-MM-dd")).SetFontSize(12).SetTextAlignment(TextAlignment.LEFT));
            doc.Add(new Paragraph("Invoice To:  " + CustomerName.Text).SetFontSize(12).SetTextAlignment(TextAlignment.LEFT));
            doc.Add(new Paragraph(" ").SetMarginBottom(10));

            float[] widths = { 1, 4, 2, 2, 2 };
            var table = new Table(UnitValue.CreatePercentArray(widths)).UseAllAvailableWidth();

            string[] headers = { "NO", "Product Name", "Price", "Quantity", "Total" };
            foreach (var h in headers)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(h))
                    .SetBackgroundColor(ColorConstants.DARK_GRAY)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontColor(ColorConstants.WHITE));
            }

            double totalSum = 0;
            int index = 1;

            foreach (var p in saleitems)
            {
                double total = p.Key.Price * p.Value;
                totalSum += total;

                table.AddCell(index.ToString());
                table.AddCell(p.Key.ProductName);
                table.AddCell(p.Key.Price.ToString());
                table.AddCell(p.Value.ToString());
                table.AddCell(total.ToString());

                index++;
            }

            table.AddCell(new Cell(1, 4)
                .Add(new Paragraph("TOTAL"))
                .SetBackgroundColor(ColorConstants.DARK_GRAY)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontColor(ColorConstants.WHITE));

            table.AddCell(new Paragraph(totalSum.ToString())
                .SetBackgroundColor(ColorConstants.DARK_GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(ColorConstants.WHITE));

            table.AddCell(new Cell(1, 4)
                .Add(new Paragraph("PAID"))
                .SetBackgroundColor(ColorConstants.DARK_GRAY)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontColor(ColorConstants.WHITE));

            table.AddCell(new Paragraph(PaidAmount.Text)
                .SetBackgroundColor(ColorConstants.DARK_GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(ColorConstants.WHITE));

            doc.Add(table);

            // Footer
            doc.Add(new Paragraph("\n\n"));
            doc.Add(new Paragraph("Address: Anywhere St, Any City 123")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(10));
            doc.Add(new Paragraph("Phone: +123-456-7890")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(10));
            doc.Add(new Paragraph("Email: hello@reallygreatsite.com")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(10));

            doc.Close();
            MessageBox.Show("Invoice PDF generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void DeterminePlaceToSave(ref string dest)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "اختر مكان حفظ الفاتورة";
                saveFileDialog.FileName = "فاتورة.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dest = saveFileDialog.FileName;
                }
                else
                {
                    MessageBox.Show("لم يتم اختيار ملف لحفظ الفاتورة.");
                }
            }
        }
        private void iconButton7_Click(object sender, EventArgs e)
        {
            GenerateInvoicePdf();
            if (ManageLanguages.Language == "en")
                ClearControlsEnglish();
            else
                ClearControlsArabic();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            this.DrawPointixLogo(e.Graphics, 20, 10);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            isButtonClicked = true;
            name = CustomerName.Text;
            Customerphone = CustomerPhone.Text;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                ClearControlsEnglish();
            else
                ClearControlsArabic();
        }

        private void NotesTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
