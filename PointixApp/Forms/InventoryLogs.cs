using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using PointixApp.Managers;
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
    public partial class InventoryLogs : Form
    {
        private Mediator mediator;
        private readonly AppDbContext context;
        public InventoryLogs()
        {
            InitializeComponent();
        }
        public InventoryLogs(AppDbContext appDbContext)
        {
            InitializeComponent();
            this.context = appDbContext;
            this.mediator = new Mediator(appDbContext);
        }
        private void InventoryLogs_Load(object sender, EventArgs e)
        {
            HandleDataGridViewSize();

            var logs = mediator.InventorLogService.GetAllLoogs();

            RefreshDataGridView(logs);
        }
        private void HandleDataGridViewSize()
        {
            dataGridView1.Width = this.Width - 250;
            dataGridView1.Height = this.Height - 51;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void RefreshDataGridView(IQueryable<InventoryLog> InventoryLogs)
        {
            if (ManageLanguages.Language == "en")
                BuildDataGridViewColumnsEnglish();
            else
                BuildDataGridViewColumnsArabic();
            FillData(InventoryLogs);
        }
        private void FillData(IQueryable<InventoryLog> InventoryLogs)
        {
            foreach (var log in InventoryLogs)
            {
                dataGridView1.Rows.Add(log.product.ProductName, log.user.Name
                    , log.changeType, log.ChangeDate);
            }
        }
        private void BuildDataGridViewColumnsEnglish()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("ProductName", "Product Name");
            dataGridView1.Columns.Add("UserName", "User Name");
            dataGridView1.Columns.Add("ChangeType", "Change Type");
            dataGridView1.Columns.Add("ChangeDate", "ChangeDate");
        }
        private void BuildDataGridViewColumnsArabic()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("ProductName", "اسم المنتج");
            dataGridView1.Columns.Add("UserName", "اسم المستخدم");
            dataGridView1.Columns.Add("ChangeType", "نوع التغيير");
            dataGridView1.Columns.Add("ChangeDate", "تاريخ التغيير");
        }
        private void iconButton11_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            if ((ManageLanguages.Language == "en" && keyword == "Search by  Username or Product name") || (ManageLanguages.Language == "ar" && keyword == "ابحث بواسطة اسم المستخدم او اسم المنتج") || string.IsNullOrWhiteSpace(keyword))
            {
                if(ManageLanguages.Language == "en")
                    MessageBox.Show("Please enter a valid username or product name to search.");
                else
                    MessageBox.Show("من فضلك ادخل اسم المستخدم او المنتج للبحث.");
                return;
            }

            var logs = mediator.InventorLogService.GetSearchedLogs(keyword);

            RefreshDataGridView(logs);
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            var logs = mediator.InventorLogService.FilterLogs(StartDate.Value, EndDate.Value);

            RefreshDataGridView(logs);
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxClick(textBox1, "Search by  Username or Product name");
            else
                this.TextBoxClick(textBox1, "ابحث بواسطة اسم المستخدم او اسم المنتج.");
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxLeave(textBox1, "Search by  Username or Product name");
            else
                this.TextBoxLeave(textBox1, "ابحث بواسطة اسم المستخدم او اسم المنتج");
        }
    }
}
