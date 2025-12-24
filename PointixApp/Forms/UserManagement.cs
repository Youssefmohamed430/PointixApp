using Microsoft.EntityFrameworkCore;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using PointixApp.Handlers;
using PointixApp.Managers;
using PointixApp.Patterns;
using System;

namespace PointixApp.Forms
{
    public partial class UserManagement : Form
    {
        private AuthModel _authModel;
        private Mediator mediator;
        private AppDbContext dbContext;
        private string lastBuiltLanguage = "";

        public UserManagement()
        {
            InitializeComponent();
        }

        public UserManagement(AuthModel authModel, AppDbContext _dbcontext)
        {
            ManageLanguages.EquipLanguage(this);
            InitializeComponent();
            _authModel = authModel;
            this.dbContext = _dbcontext;
            this.mediator = new Mediator(dbContext, _authModel);
            var menu = new Menu(authModel, dbContext, ManageLanguages.Language);
            menu.Dock = DockStyle.Left;
            this.Controls.Add(menu);
            RefreshiconButton2.BringToFront();
        }
        public void UserManagement_Load(object sender, EventArgs e)
        {
            HandleDataGridViewSize();

            RefreshDataGridView(mediator.UserManagementService.GetUsers());

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
        
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender != dataGridView1) return;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];

                int UserId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                // Delete
                if (columnName == "Delete")
                {
                    HandleDeleteAction(UserId);
                }

                // Edit
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    HandleEditAction(UserId);
                }
            }
        }

        private void HandleEditAction(int UserId)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.UserId == UserId);
            new EditUser(dbContext, user, this, _authModel).Show();
        }

        private void HandleDeleteAction(int UserId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this User?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var error = mediator.UserManagementService.RemoveUser(UserId);
                if (error == null)
                {
                    ExceptionHandler.ShowSuccess("Success", "User is deleting success");
                    RefreshDataGridView(mediator.UserManagementService.GetUsers());
                }
                else
                    ExceptionHandler.ShowError("Deleting User", error);
            }
        }

        private void EnsureDataGridViewColumnsBuilt()
        {
            if (lastBuiltLanguage != ManageLanguages.Language)
            {
                if (ManageLanguages.Language == "en")
                    BuildDataGridViewColumnsEnglish();
                else
                    BuildDataGridViewColumnsArabic();

                lastBuiltLanguage = ManageLanguages.Language;
            }
        }

        public void RefreshDataGridView(IQueryable<User> Users)
        {
            EnsureDataGridViewColumnsBuilt();
            dataGridView1.Rows.Clear();
            FillData(Users);
        }
        private void FillData(IQueryable<User> Users)
        {
            foreach (var user in Users)
            {
                dataGridView1.Rows
                    .Add(user.UserId, user.Name, user.UserName, user.Password, user.Role);
            }
        }
        private void BuildDataGridViewColumnsEnglish()
        {
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("username", "User Name");
            dataGridView1.Columns.Add("Password", "Password");
            dataGridView1.Columns.Add("Role", "Role");

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
            dataGridView1.Columns.Add("id", "معرف المستخدم");
            dataGridView1.Columns.Add("name", "الاسم");
            dataGridView1.Columns.Add("username", "اسم المستخدم");
            dataGridView1.Columns.Add("Password", "كلمة السر");
            dataGridView1.Columns.Add("Role", "الدور");

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
        private void iconButton11_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            if (keyword == "Search by name or UserName" || string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Please enter a valid product name to search.");
                return;
            }
            var Users = mediator.UserManagementService.SearchUser(keyword);

            RefreshDataGridView(Users);
        }
        public void iconButton3_Click(object sender, EventArgs e)
        {
            NotificationPanel.Visible = !NotificationPanel.Visible;

            if (NotificationPanel.Visible)
            {
                this.LoadNotifications(mediator, NotificationPanel, _authModel.Id, mediator.NotificationService);
            }
        }
        private void iconButton8_Click(object sender, EventArgs e)
        {
            var adduserform = new AddUser(dbContext, this);
            adduserform.Show();
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            Invoice InvoiceForm = new Invoice(_authModel, dbContext);
            ManageForms.Instance.ShowForm(InvoiceForm);
            this.Close();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if(ManageLanguages.Language == "en")
                this.TextBoxClick(textBox1, "Search by name or UserName");
            else
                this.TextBoxClick(textBox1, "البحث بواسطة الاسم او اسم المستخدم");
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (ManageLanguages.Language == "en")
                this.TextBoxLeave(textBox1, "Search by name or UserName");
            else
                this.TextBoxLeave(textBox1, "البحث بواسطة الاسم او اسم المستخدم");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            this.DrawPointixLogo(e.Graphics, 20, 10);
        }


        private void iconButton2_Click(object sender, EventArgs e)
        {
        }

        private void RefreshiconButton2_Click_1(object sender, EventArgs e)
        {
            RefreshDataGridView(mediator.UserManagementService.GetUsers());
        }

        private void ReporticonButton_Click(object sender, EventArgs e)
        {
            Report report = new Report(_authModel, dbContext);
            ManageForms.Instance.ShowForm(report);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
