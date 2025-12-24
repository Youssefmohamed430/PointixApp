using PointixApp.DataLayer;
using PointixApp.DataLayer.DTOs;
using PointixApp.DataLayer.Entities;
using PointixApp.Patterns;
using PointixApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointixApp.Forms
{
    public partial class Report : Form
    {
        private AuthModel authModel;
        private Mediator mediator;
        private AppDbContext dbContext;
        private Button btnSalesToday;
        private Button btnSalesThisMonth;
        private Button activeButton;
        public DateTime Today = DateTime.Today;
        public DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        private string lastBuiltLanguage = "";
        public Report()
        {
            InitializeComponent();
        }
        public Report(AuthModel _authModel, AppDbContext appDbContext)
        {
            ManageLanguages.EquipLanguage(this);
            InitializeComponent();
            this.authModel = _authModel;
            this.dbContext = appDbContext;
            this.mediator = new Mediator(dbContext, _authModel);
            var menu = new Menu(authModel, dbContext, ManageLanguages.Language);
            menu.Dock = DockStyle.Left;
            this.Controls.Add(menu);
        }

        private void Report_Load(object sender, EventArgs e)
        {
            CreateCustomButtons();

            RefreshDataGridView(mediator.ReportService.GetSales(Today, Today.AddDays(1)).Keys.First());

            this.label3.Text = mediator.ReportService.GetSales(Today, Today.AddDays(1)).Values.First().ToString();

            this.label6.Text = mediator.ReportService.GetSales(startOfMonth, Today.AddDays(1)).Values.First().ToString();
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            NotificationPanel.Visible = !NotificationPanel.Visible;

            if (NotificationPanel.Visible)
            {
                this.LoadNotifications(mediator, NotificationPanel, authModel.Id, mediator.NotificationService);
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            this.DrawPointixLogo(e.Graphics, 20, 10);
        }
        private void CreateCustomButtons()
        {
            btnSalesToday = new Button
            {
                Text = ManageLanguages.Language == "en" ? "Sales Today" : "مبيعات اليوم",
                Size = new Size(180, 40),
                Location = new Point(303, 440),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(64, 64, 64),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Cursor = Cursors.Hand,
                TabStop = false
            };

            btnSalesToday.FlatAppearance.BorderSize = 0;
            btnSalesToday.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            btnSalesToday.FlatAppearance.MouseDownBackColor = Color.FromArgb(240, 240, 240);

            btnSalesThisMonth = new Button
            {
                Text = ManageLanguages.Language == "en" ? "Sales this Month" : "مبيعات هذا الشهر",
                Size = new Size(150, 40),
                Location = new Point(483, 440),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(160, 160, 160),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Cursor = Cursors.Hand,
                TabStop = false
            };

            btnSalesThisMonth.FlatAppearance.BorderSize = 0;
            btnSalesThisMonth.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            btnSalesThisMonth.FlatAppearance.MouseDownBackColor = Color.FromArgb(240, 240, 240);

            btnSalesToday.Click += BtnSalesToday_Click;
            btnSalesThisMonth.Click += BtnSalesThisMonth_Click;

            btnSalesToday.Paint += (s, e) => DrawUnderline(e, btnSalesToday);
            btnSalesThisMonth.Paint += (s, e) => DrawUnderline(e, btnSalesThisMonth);

            activeButton = btnSalesToday;

            this.Controls.Add(btnSalesToday);
            this.Controls.Add(btnSalesThisMonth);
        }
        private void DrawUnderline(PaintEventArgs e, Button button)
        {
            if (button == activeButton)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(pen, 0, button.Height - 2, button.Width, button.Height - 2);
                }
            }
        }

        private void BtnSalesToday_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSalesToday, btnSalesThisMonth);

            RefreshDataGridView(mediator.ReportService.GetSales(Today, Today.AddDays(1)).Keys.First());

            panel4.Visible = false;
        }
        private void BtnSalesThisMonth_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSalesThisMonth, btnSalesToday);

            RefreshDataGridView(mediator.ReportService.GetSales(startOfMonth, Today.AddDays(1)).Keys.First());

            panel4.Visible = false;
        }
        private void SetActiveButton(Button newActive, Button oldActive)
        {
            activeButton = newActive;

            btnSalesToday.ForeColor = Color.FromArgb(160, 160, 160);
            btnSalesThisMonth.ForeColor = Color.FromArgb(160, 160, 160);

            newActive.ForeColor = Color.FromArgb(64, 64, 64);

            btnSalesToday.Invalidate();
            btnSalesThisMonth.Invalidate();
        }
        private void EnsureDataGridViewColumnsBuilt()
        {
            if (lastBuiltLanguage != ManageLanguages.Language)
            {
                if (ManageLanguages.Language == "en")
                    BuildDataGridViewEnglish();
                else
                    BuildDataGridViewArabic();


                lastBuiltLanguage = ManageLanguages.Language;
            }
        }

        public void RefreshDataGridView(IQueryable<SaleDTO> Sales)
        {
            EnsureDataGridViewColumnsBuilt();
            
            dataGridView1.Rows.Clear();

            foreach (var sale in Sales)
            {
                dataGridView1.Rows.Add(
                    sale.SaleId,
                    sale.SaleDate,
                    sale.CustomerName,
                    sale.CustomerPhone,
                    sale.SaleAmount,
                    sale.PaidAmount,
                    sale.RemainingAmount,
                    sale.SellerName
                );
            }
        }
        private void BuildDataGridViewEnglish()
        {

            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("SaleDate", "Sale Date");
            dataGridView1.Columns.Add("CustomerName", "Customer Name");
            dataGridView1.Columns.Add("CustomerPhone", "Customer Phone");
            dataGridView1.Columns.Add("SaleAmount", "Total");
            dataGridView1.Columns.Add("PaidAmount", "Paid");
            dataGridView1.Columns.Add("RemainingAmount", "Remaining");
            dataGridView1.Columns.Add("SellerName", "Seller Name");

            dataGridView1.Columns["id"].Width = 100;
            dataGridView1.Columns["SaleDate"].Width = 250;
            dataGridView1.Columns["CustomerName"].Width = 250;
            dataGridView1.Columns["CustomerPhone"].Width = 250;

        }

        private void BuildDataGridViewArabic()
        {
            dataGridView1.Columns.Add("id", "معرف البيعة");
            dataGridView1.Columns.Add("SaleDate", "تاريخ البيعة");
            dataGridView1.Columns.Add("CustomerName", "اسم العميل");
            dataGridView1.Columns.Add("CustomerPhone", "رقم العميل");
            dataGridView1.Columns.Add("SaleAmount", "مجموع");
            dataGridView1.Columns.Add("PaidAmount", "مدفوع");
            dataGridView1.Columns.Add("RemainingAmount", "متبقي");
            dataGridView1.Columns.Add("SellerName", "اسم البائع");

            dataGridView1.Columns["id"].Width = 100;
            dataGridView1.Columns["SaleDate"].Width = 250;
            dataGridView1.Columns["CustomerName"].Width = 250;
            dataGridView1.Columns["CustomerPhone"].Width = 250;

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(authModel, dbContext);
            ManageForms.Instance.ShowForm(dashboard);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory(authModel, dbContext);
            ManageForms.Instance.ShowForm(inventory);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice(authModel, dbContext);
            ManageForms.Instance.ShowForm(invoice);
        }

        private void UserManagentIconButton_Click(object sender, EventArgs e)
        {
            Report report = new Report(authModel, dbContext);
            ManageForms.Instance.ShowForm(report);
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
                var sales = mediator.ReportService.GetSales(StartDate.Value, EndDate.Value);
                if (!sales.Any())
                {
                    MessageBox.Show("لا توجد مبيعات في الفترة المحددة", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                RefreshDataGridView(sales.Keys.First());
                label11.Text = sales.Values.First().ToString();
                panel4.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            CreateCustomButtons();

            RefreshDataGridView(mediator.ReportService.GetSales(Today, Today.AddDays(1)).Keys.First());

            this.label3.Text = mediator.ReportService.GetSales(Today, Today.AddDays(1)).Values.First().ToString();

            this.label6.Text = mediator.ReportService.GetSales(startOfMonth, Today.AddDays(1)).Values.First().ToString();
        }
    }
}
