using Microsoft.EntityFrameworkCore;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using PointixApp.Handlers;
using PointixApp.Managers;
using PointixApp.Patterns;
using PointixApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointixApp.Forms
{
    public partial class Inventory : Form
    {
        private readonly AuthModel authModel;
        private Mediator mediator;
        private readonly AppDbContext context;
        private string lastBuiltLanguage = "";
        public Inventory()
        {
            InitializeComponent();
        }

        public Inventory(AuthModel _authModel, AppDbContext _context)
        {
            ManageLanguages.EquipLanguage(this);
            InitializeComponent();
            this.authModel = _authModel;
            this.context = _context;
            this.mediator = new Mediator(context, authModel);
            var menu = new Menu(authModel, context,ManageLanguages.Language);
            menu.Dock = DockStyle.Left;
            this.Controls.Add(menu);
            RefreshiconButton.BringToFront();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
        int nWidthEllipse, int nHeightEllipse);
        public void Inventory_Load(object sender, EventArgs e)
        {
            HandleDataGridViewSize();

            RefreshDataGridView(mediator.InventoryService.GetProducts());

            // إزالة جميع الأحداث المسجلة مسبقاً
            dataGridView1.CellClick -= DataGridView1_CellContentClick;

            // استخدام CellContentClick مع التحقق الإضافي
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }
        private void HandleDataGridViewSize()
        {
            dataGridView1.Width = this.Width - 250;
            dataGridView1.Height = this.Height - 51;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void EnsureDataGridViewColumnsBuilt()
        {
            if (lastBuiltLanguage != ManageLanguages.Language)
            {
                if (ManageLanguages.Language == "ar")
                    BuildDataGridViewColumnsArabic();
                else
                    BuildDataGridViewColumnsEnglish();

                lastBuiltLanguage = ManageLanguages.Language;
            }
        }

        public void RefreshDataGridView(IQueryable<Product> products)
        {
            try
            {
                if (products == null)
                {
                    if(ManageLanguages.Language == "en")
                    ExceptionHandler.ShowWarning("Data Warning", "No products data available");
                    else
                    ExceptionHandler.ShowWarning("تحذير", "لا توجد بيانات منتجات متاحة!");

                        return;
                }

                EnsureDataGridViewColumnsBuilt();

                dataGridView1.Rows.Clear();

                FillData(products);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Data Refresh Error",ex);
            }
        }
        private void FillData(IQueryable<Product> products)
        {
            try
            {
                foreach (var product in products)
                {
                    if (product != null)
                    {
                        dataGridView1.Rows.Add(
                            product.ProductId,
                            product.ProductName ?? "",
                            product.ExpireDate!.ToString("dd/MM/yyyy") ?? "",
                            product.Quantity,
                            product.MinmumQuantity,
                            product.Price!.ToString("F2") ?? "0.00",
                            product.Notes ?? "No Notes"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Data Loading Error",
                    ex);
            }
        }
        private void BuildDataGridViewColumnsEnglish()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("name", "Product Name");
            dataGridView1.Columns.Add("ExpireDate", "Expire Date");
            dataGridView1.Columns.Add("Quantity", "Quantity");
            dataGridView1.Columns.Add("MMinQuantity", "MinumumQuantity");
            dataGridView1.Columns.Add("price", "Price");
            dataGridView1.Columns.Add("Notes", "Notes");

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "🗑 Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(deleteButtonColumn);

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Text = "✏ Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(editButtonColumn);
        }

        private void BuildDataGridViewColumnsArabic()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("id", "معرف المنتج");
            dataGridView1.Columns.Add("name", "اسم المنتج");
            dataGridView1.Columns.Add("ExpireDate", "تاريخ الانتهاء");
            dataGridView1.Columns.Add("Quantity", "الكمية");
            dataGridView1.Columns.Add("MMinQuantity", "أقل كمية");
            dataGridView1.Columns.Add("price", "السعر");
            dataGridView1.Columns.Add("Notes", "ملاحظات");

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.HeaderText = "حذف";
            deleteButtonColumn.Text = "🗑 حذف";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(deleteButtonColumn);

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.HeaderText = "تعديل";
            editButtonColumn.Text = "✏ تعديل";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(editButtonColumn);
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender != dataGridView1) return;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (columnName == "Delete" || columnName == "Edit")
                {
                    var selectedRow = dataGridView1.Rows[e.RowIndex];

                    if (selectedRow.Cells["id"].Value != null)
                    {
                        int productId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                        if (columnName == "Delete")
                        {
                            HandleDeleteAction(productId);
                        }
                        else if (columnName == "Edit")
                        {
                            HandleEditAction(productId);
                        }
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Notes" && e.RowIndex >= 0)
                {
                    string notes = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                    MessageBox.Show(notes, "Notes");
                }
            }
        }
        private void HandleDeleteAction(int productId)
        {
            try
            {
                DialogResult result ;

                if(ManageLanguages.Language == "ar")
                {
                    result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا المنتج؟",
                        "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                result = MessageBox.Show("Are you sure you want to delete this product?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var error = mediator.InventoryService.RemoveProduct(authModel, productId);
                    if (error == null)
                    {
                        if (ManageLanguages.Language == "ar")
                        {
                            ExceptionHandler.ShowSuccess("نجاح", "تم حذف المنتج بنجاح");
                            RefreshDataGridView(mediator.InventoryService.GetProducts());
                        }
                        else
                        {
                            ExceptionHandler.ShowSuccess("Success", "Product deleted successfully");
                            RefreshDataGridView(mediator.InventoryService.GetProducts());
                        }
                    }
                    else
                    {
                        ExceptionHandler.ShowError("Delete Error", error);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Delete Error",ex);
            }
        }
        private void HandleEditAction(int productId)
        {
            try
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == productId && !p.IsDeleted);
                if (product != null)
                {
                    var editform = new EditProduct(context, product, this, authModel);
                    editform.Show();
                }
                else
                {
                    if(ManageLanguages.Language == "en")
                        ExceptionHandler.ShowWarning("Product Not Found", "The selected product could not be found or has been deleted");
                    else
                        ExceptionHandler.ShowWarning("المنتج غير موجود", "المنتج المختار غير موجود");

                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Edit Error",ex);
            }
        }
        private void iconButton7_Click(object sender, EventArgs e)
        {
            try
            {
                NotificationPanel.Visible = !NotificationPanel.Visible;

                if (NotificationPanel.Visible)
                {
                    this.LoadNotifications(mediator, NotificationPanel, authModel.Id, mediator.NotificationService);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Notification Error",ex);
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            this.DrawPointixLogo(e.Graphics, 20, 10);
        }
        private void iconButton11_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBox1.Text?.Trim();
                if(ManageLanguages.Language == "en")
                {
                    if (keyword == "Search by name" || string.IsNullOrWhiteSpace(keyword))
                    {
                        ExceptionHandler.ShowWarning("Search Input Required", "Please enter a valid product name to search.");
                        return;
                    }
                }
                else
                {
                    if (keyword == "البحث بالاسم" || string.IsNullOrWhiteSpace(keyword))
                    {
                        ExceptionHandler.ShowWarning("مطلوب ادخال الاسم للبحث", "من فضلك ادخل اسم منتج صالح.");
                        return;
                    }
                }

                    var products = mediator.InventoryService.SearchForProduct(keyword);
                RefreshDataGridView(products);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Search Error",ex);
            }
        }
        private void iconButton8_Click(object sender, EventArgs e)
        {
            new AddProduct(authModel, context, this).Show();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void iconButton9_Click(object sender, EventArgs e)
        {
            new InventoryLogs(context).Show();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if(ManageLanguages.Language == "en")
                this.TextBoxClick(textBox1, "Search by name");
            else
                this.TextBoxClick(textBox1, "البحث بالاسم");
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxLeave(textBox1, "Search by name");
            else
                this.TextBoxLeave(textBox1, "البحث بالاسم");
        }
        private void iconButton6_Click(object sender, EventArgs e)
        {
            Report report = new Report(authModel, context);
            ManageForms.Instance.ShowForm(report);
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {

        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            //new ManageForms().ShowForm(new CustomersDetails(authModel, context));
        }

        private void RefreshiconButton_Click_1(object sender, EventArgs e)
        {
            RefreshDataGridView(mediator.InventoryService.GetProducts());
        }
    }
}
