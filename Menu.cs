using FontAwesome.Sharp;
using Microsoft.EntityFrameworkCore.Storage;
using PointixApp.DataLayer;
using PointixApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointixApp
{
    public partial class Menu : UserControl
    {
        private AuthModel authModel;
        private AppDbContext context;
        private Form parentForm;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(AuthModel _authModel, AppDbContext appDbContext,string lan)
        {
            InitializeComponent();
            this.authModel = _authModel;
            this.context = appDbContext;
            this.User.Text = _authModel.Name;

            if (_authModel.role != "admin")
            {
                UserManagentIconButton.Visible = false;
                ReporticonButton.Visible = false;
            }

            ApplyLanguage(lan);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            parentForm = this.FindForm();
            if (parentForm != null)
            {
                ManageLanguages.EquipLanguage(parentForm);
                PaintSelectIconButton();
            }
        }

        public void PaintSelectIconButton()
        {
            IconButton iconButton = null;
            if (parentForm is Dashboard)
                iconButton = iconButton1;
            else if (parentForm is Inventory)
                iconButton = iconButton5;
            else if (parentForm is Invoice)
                iconButton = iconButton4;
            else if (parentForm is UserManagement)
                iconButton = UserManagentIconButton;
            else if (parentForm is Report)
                iconButton = ReporticonButton;

            iconButton.BackColor = Color.FromArgb(22, 100, 192);
            iconButton.ForeColor = Color.White;
            iconButton.IconColor = Color.White;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var dashboard = new Dashboard(authModel, context);
            ManageForms.Instance.ShowForm(dashboard);
            if (parentForm != null)
                parentForm.Close();
        }

        private void iconButton5_Click_1(object sender, EventArgs e)
        {
            Inventory inventoryForm = new Inventory(authModel, context);
            ManageForms.Instance.ShowForm(inventoryForm);
            var parentForm = this.FindForm();
            if (parentForm != null)
                parentForm.Close();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Invoice InvoiceForm = new Invoice(authModel, context);
            ManageForms.Instance.ShowForm(InvoiceForm);
            var parentForm = this.FindForm();
            if (parentForm != null)
                parentForm.Close();
        }

        private void UserManagentIconButton_Click(object sender, EventArgs e)
        {
            var usermanage = new UserManagement(authModel, context);
            ManageForms.Instance.ShowForm(usermanage);
            var parentForm = this.FindForm();
            if (parentForm != null)
                parentForm.Close();
        }

        private void ReporticonButton_Click_1(object sender, EventArgs e)
        {
            Report report = new Report(authModel, context);
            ManageForms.Instance.ShowForm(report);
            var parentForm = this.FindForm();
            if (parentForm != null)
                parentForm.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ApplyLanguage(string lan)
        {
            List<IconButton> iconbuttons = new List<IconButton>()
            {
                iconButton1,
                iconButton5,
                iconButton4,
                UserManagentIconButton,
                ReporticonButton
            };
            List<string> labelsar = new List<string>()
            {
                "اللوحة الرئيسية","المخزون", "الفواتير", "إدارة المستخدمين", "التقارير"
            };
            if (lan == "ar")
            {
                for(int i = 0; i < iconbuttons.Count; i++)
                    iconbuttons[i].Text = labelsar[i];
            }
        }
    }
}
