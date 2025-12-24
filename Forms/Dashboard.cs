using PointixApp.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using PointixApp.Services;
using PointixApp.Forms;
using PointixApp.DataLayer.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using PointixApp.Patterns;
using PointixApp.DataLayer.DTOs;

namespace PointixApp
{
    public partial class Dashboard : Form
    {
        private AuthModel _authModel;
        private Mediator mediator;
        private AppDbContext dbContext;
        private ToolTip toolTip = new ToolTip();
        private string lastBuiltLanguage = "";

        public Dashboard()
        {
            InitializeComponent();
        }
        public Dashboard(AuthModel authModel, AppDbContext appDbContext)
        {
            ManageLanguages.EquipLanguage(this);
            InitializeComponent();
            this._authModel = authModel;
            this.dbContext = appDbContext;
            this.mediator = new Mediator(dbContext, _authModel);
            var menu = new Menu(_authModel, dbContext,ManageLanguages.Language);
            menu.Dock = DockStyle.Left;
            this.Controls.Add(menu);
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
        int nWidthEllipse, int nHeightEllipse);
        private void Dashboard_Load(object sender, EventArgs e)
        {

            EnsureDataGridViewColumnsBuilt();

            RefreshDataGridView(mediator.SaleService.GetAllSales());

            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }


        private void EnsureDataGridViewColumnsBuilt()
        {
            if (lastBuiltLanguage != ManageLanguages.Language)
            {
                if (ManageLanguages.Language == "ar")
                    BuildDataGridViewArabic();
                else
                    BuildDataGridViewEnglish();

                lastBuiltLanguage = ManageLanguages.Language;
            }
        }
        public void RefreshDataGridView(IQueryable<SaleDTO> Sales)
        {
            EnsureDataGridViewColumnsBuilt();

            dataGridView1.Rows.Clear();

            foreach (var sale in Sales)
            {
                string items = string.Join(", ", sale.saleItemsName);

                string displayText = "";
                string editButtonText = "";
                if (ManageLanguages.Language == "en")
                {
                    displayText = sale.saleItemsName.Any() ?
                    $"{sale.saleItemsName.First()} (Read More)" :
                    "No Items";

                    editButtonText = sale.RemainingAmount > 0 ? "✏ Edit" : "";
                }
                else
                {
                    displayText = sale.saleItemsName.Any() ?
                    $"{sale.saleItemsName.First()} (قراءة المزيد)" :
                    "لا توجد سلع";
                    editButtonText = sale.RemainingAmount > 0 ? "✏ تعديل" : "";
                }


                dataGridView1.Rows.Add(
                    sale.SaleId,
                    sale.SaleDate,
                    sale.CustomerName,
                    sale.CustomerPhone,
                    sale.SaleAmount,
                    sale.PaidAmount,
                    sale.RemainingAmount,
                    sale.SellerName,
                    sale.Notes ?? "No Notes",
                    displayText,
                    editButtonText
                );

                if (dataGridView1.Rows.Count > 0)
                {
                    var lastRow = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
                    lastRow.Cells["SaleItems"].Tag = items;
                }
            }
        }
        private void BuildDataGridViewEnglish()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("SaleDate", "Sale Date");
            dataGridView1.Columns.Add("CustomerName", "Customer Name");
            dataGridView1.Columns.Add("CustomerPhone", "Customer Phone");
            dataGridView1.Columns.Add("SaleAmount", "Total");
            dataGridView1.Columns.Add("PaidAmount", "Paid");
            dataGridView1.Columns.Add("RemainingAmount", "Remaining");
            dataGridView1.Columns.Add("SellerName", "Seller Name");
            dataGridView1.Columns.Add("Notes", "Notes");

            dataGridView1.Columns["id"].Width = 100;
            dataGridView1.Columns["SaleDate"].Width = 250;
            dataGridView1.Columns["CustomerName"].Width = 250;
            dataGridView1.Columns["CustomerPhone"].Width = 250;
            dataGridView1.Columns["Notes"].Width = 150;

            DataGridViewButtonColumn SaleItemsButtonColumn = new DataGridViewButtonColumn();
            SaleItemsButtonColumn.Name = "SaleItems";
            SaleItemsButtonColumn.HeaderText = "Sale Items";
            SaleItemsButtonColumn.Text = "Sale Items";
            SaleItemsButtonColumn.UseColumnTextForButtonValue = true;
            SaleItemsButtonColumn.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(SaleItemsButtonColumn);

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditButton";
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Text = "✏ Edit";
            editButtonColumn.UseColumnTextForButtonValue = false;
            editButtonColumn.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editButtonColumn);

        }
        private void BuildDataGridViewArabic()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("id", "معرف البيع");
            dataGridView1.Columns.Add("SaleDate", "تاريخ البيع");
            dataGridView1.Columns.Add("CustomerName", "اسم العميل");
            dataGridView1.Columns.Add("CustomerPhone", "رقم العميل");
            dataGridView1.Columns.Add("SaleAmount", "المجموع");
            dataGridView1.Columns.Add("PaidAmount", "المدفوع");
            dataGridView1.Columns.Add("RemainingAmount", "المتبقي");
            dataGridView1.Columns.Add("SellerName", "اسم البائع");
            dataGridView1.Columns.Add("Notes", "ملاحظات");

            dataGridView1.Columns["id"].Width = 200;
            dataGridView1.Columns["SaleDate"].Width = 250;
            dataGridView1.Columns["CustomerName"].Width = 250;
            dataGridView1.Columns["CustomerPhone"].Width = 250;
            dataGridView1.Columns["Notes"].Width = 150;

            DataGridViewButtonColumn SaleItemsButtonColumn = new DataGridViewButtonColumn();
            SaleItemsButtonColumn.Name = "SaleItems";
            SaleItemsButtonColumn.HeaderText = "سلع البيع";
            SaleItemsButtonColumn.Text = "سلع البيع";
            SaleItemsButtonColumn.UseColumnTextForButtonValue = true;
            SaleItemsButtonColumn.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(SaleItemsButtonColumn);

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditButton";
            editButtonColumn.HeaderText = "تعديل";
            editButtonColumn.Text = "✏ تعديل";
            editButtonColumn.UseColumnTextForButtonValue = false;
            editButtonColumn.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editButtonColumn);

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "SaleItems")
                {
                    int saleId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                    var sale = mediator.SaleService.GetSaleItemsForSale(saleId);
                    if (sale != null)
                    {
                        string allItems = SaleItemsString(sale);
                        if (ManageLanguages.Language == "en")
                            MessageBox.Show("Sale Items:\n\n" + allItems.Replace(", ", "\n"),
                                          "All Sale Items",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        else
                            MessageBox.Show("سلع البيع:\n\n" + allItems.Replace(", ", "\n"),
                                      "كل سلع البيع",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "EditButton")
                {
                    try
                    {
                        decimal currentRemainingAmount = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["RemainingAmount"].Value);

                        string buttonText = dataGridView1.Rows[e.RowIndex].Cells["EditButton"].Value?.ToString();
                        if (string.IsNullOrEmpty(buttonText))
                        {
                            return;
                        }

                        int saleId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                        string input = "";
                        input = GetNewRemainingValue(currentRemainingAmount);
                        EditRemainingValue(e, saleId, input);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Notes" && e.RowIndex >= 0)
                {
                    string notes = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                    MessageBox.Show(notes, "Notes");
                }
            }
        }

        private void EditRemainingValue(DataGridViewCellEventArgs e, int saleId, string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (decimal.TryParse(input, out decimal newRemainingAmount))
                {
                    mediator.SaleService.EditRemainingValue(saleId, newRemainingAmount);

                    dataGridView1.Rows[e.RowIndex].Cells["RemainingAmount"].Value = newRemainingAmount;

                    RefreshDataGridView(mediator.SaleService.GetAllSales());
                }
                else
                    MessageBox.Show("من فضلك ادخل قيمة صالحة.", "قيمة غير صالحة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string GetNewRemainingValue(decimal currentRemainingAmount)
        {
            string input;
            if (ManageLanguages.Language == "en")
            {
                input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Enter new remaining amount:\nCurrent amount: {currentRemainingAmount:C}",
                "Edit Remaining Amount",
                currentRemainingAmount.ToString());
            }
            else
            {
                input = Microsoft.VisualBasic.Interaction.InputBox(
                $"ادخل القيمة الجديدة المتبقية :\nالقيمة الحالية : {currentRemainingAmount:C}",
                "تعديل القيمة المتبقية",
                currentRemainingAmount.ToString());
            }

            return input;
        }

        private static string SaleItemsString(List<SaleItem> sale)
        {
            string allItems = "";
            foreach (var s in sale)
            {
                allItems += s.product.ProductName + ", ";
            }
            return allItems;
        }

        //------------- IconButtons ----------------- 
        private void iconButton2_Click(object sender, EventArgs e)
        {
            var usermanage = new UserManagement(_authModel, dbContext);
            ManageForms.Instance.ShowForm(usermanage);
            this.Close();
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Invoice InvoiceForm = new Invoice(_authModel, dbContext);
            ManageForms.Instance.ShowForm(InvoiceForm);
            this.Close();
        }
        private void iconButton5_Click(object sender, EventArgs e)
        {
            Inventory inventoryForm = new Inventory(_authModel, dbContext);
            ManageLanguages.EquipLanguage(inventoryForm);
            ManageForms.Instance.ShowForm(inventoryForm);
        }
        private void iconButton6_Click(object sender, EventArgs e)
        {
            Report ReportForm = new Report(_authModel, dbContext);
            ManageForms.Instance.ShowForm(ReportForm);
        }
        private void iconButton7_Click(object sender, EventArgs e)
        {
            NotificationPanel.Visible = !NotificationPanel.Visible;

            if (NotificationPanel.Visible)
            {
                this.LoadNotifications(mediator, NotificationPanel, _authModel.Id, mediator.NotificationService);
            }
        }
        private void iconButton11_Click(object sender, EventArgs e)
        {
            try
            {
                AppCache.ClearCachedSearchedSales();
                string keyword = textBox1.Text;
                if (keyword == "Search by name" || string.IsNullOrWhiteSpace(keyword))
                {
                    if (ManageLanguages.Language == "en")
                        MessageBox.Show("Please enter a valid name to search.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("من فضلك ادخل اسم صالح ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var sales = mediator.SaleService.SearchForSale(keyword);
                RefreshDataGridView(sales);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------- TextBox -----------------
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxClick(textBox1, "Search by Customer Name or Seller Name");
            else
                this.TextBoxClick(textBox1, "البحث باسم العميل او اسم البائع");
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxLeave(textBox1, "Search by Customer Name or Seller Name");
            else
                this.TextBoxLeave(textBox1, "البحث باسم العميل او اسم البائع");
        }
        //----------- Paint Events ---------------
        private void SalesTablePanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            this.DrawPointixLogo(e.Graphics, 20, 10);
        }
        private void iconButton10_Click(object sender, EventArgs e)
        {
            //new ManageForms().ShowForm(new CustomersDetails(_authModel, dbContext));
            //this.Close();
        }
        private void iconButton8_Click(object sender, EventArgs e)
        {
            var sales = mediator.SaleService.GetRemainingAmountSales();

            RefreshDataGridView(sales);
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            RefreshDataGridView(mediator.SaleService.GetAllSales());

            AppCache.ClearCachedFilterdSales();
            AppCache.ClearCachedSearchedSales();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            try
            {
                if (StartDate.Value > EndDate.Value)
                {
                    MessageBox.Show("تاريخ البداية يجب أن يكون قبل تاريخ النهاية", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AppCache.ClearCachedFilterdSales();
                var sales = mediator.SaleService.FilterSale(StartDate.Value, EndDate.Value);
                if (!sales.Any())
                {
                    MessageBox.Show("لا توجد مبيعات في الفترة المحددة", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                RefreshDataGridView(sales);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
