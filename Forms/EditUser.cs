using PointixApp.DataLayer.Entities;
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
using PointixApp.Services;
using PointixApp.Factories;
using PointixApp.Patterns;

namespace PointixApp.Forms
{
    public partial class EditUser : Form
    {
        private AppDbContext ctxt;
        private AuthModel Authmodel;
        private UserManagement Usermanagement;
        private Mediator mediator;
        private User user;
        public EditUser()
        {
            InitializeComponent();
        }
        public EditUser(AppDbContext _context, User _user, UserManagement Usermanagement, AuthModel authmodel)
        {
            ManageLanguages.EquipLanguage(this);
            InitializeComponent();
            this.ctxt = _context;
            this.Authmodel = authmodel;
            this.user = _user;
            this.Usermanagement = Usermanagement;
            this.mediator = new Mediator(ctxt,Authmodel);
        }
        private void EditUser_Load(object sender, EventArgs e)
        {
            this.UserName.Text = user.UserName;
            this.Password.Text = user.Password;
            this.Name.Text = user.Name;
            this.comboBox1.Text = user.Role;
        }
        private void iconButton8_Click(object sender, EventArgs e)
        {
            var error = mediator.UserManagementService.EditUser(user.UserId, UserName.Text, Name.Text, Password.Text, comboBox1.Text);

            if (error == null)
            {
                if(ManageLanguages.Language == "en")
                    ExceptionHandler.ShowSuccess("Success", "User Edited successfully");
                else
                    ExceptionHandler.ShowSuccess("Success", "تم تعديل المستخدم بنجاح!");
            }
            else
            {
                ExceptionHandler.ShowError("Edit Error", error);
            }

            this.Close();

            Usermanagement.UserManagement_Load(sender, e);
        }

    }
}
