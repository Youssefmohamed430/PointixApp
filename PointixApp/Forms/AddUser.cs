using Microsoft.Win32.SafeHandles;
using PointixApp.DataLayer;
using PointixApp.Factories;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointixApp.Forms
{
    public partial class AddUser : Form
    {
        private Mediator mediator;
        private UserManagement Usermanagement;

        public AddUser()
        {
            InitializeComponent();
        }
        public AddUser(AppDbContext appDbContext, UserManagement userManagement)
        {
            ManageLanguages.EquipLanguage(this);
            InitializeComponent();
            mediator = new Mediator(appDbContext);
            this.Usermanagement = userManagement;
        }
        private void iconButton8_Click(object sender, EventArgs e)
        {
            try
            {
                var role = comboBox1.SelectedText?.ToString() == "Admin" ? "admin" : "staff";

                var error = mediator.UserManagementService.AddUser(UserName.Text, Name.Text, Password.Text, role);

                if (error == null)
                {
                    if(ManageLanguages.Language == "en")
                        ExceptionHandler.ShowSuccess("Success", "User added successfully");
                    else
                        ExceptionHandler.ShowSuccess("Success", "تم اضافة المستخدم");
                }

                this.Close();

                Usermanagement.UserManagement_Load(sender, e);
            }
            catch(Exception ex)
            {
                ExceptionHandler.ShowError("Add User Error", ex);
            }   
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

    }
}

