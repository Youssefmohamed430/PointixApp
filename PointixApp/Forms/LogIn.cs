using PointixApp.Controller;
using PointixApp.Properties;
using PointixApp.Services;
using System.ComponentModel;

namespace PointixApp
{
    public partial class LogInForm : Form
    {

        private IAuthService authService;
        public LogInForm()
        {
            InitializeComponent();
        }

        public LogInForm(IAuthService _authService)
        {
            InitializeComponent();
            ErrorLabel.Visible = false;
            this.authService = _authService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }




        private void UserNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void UserNameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UserNameField.Text;
            string password = PasswordField.Text;

            var authmodel = authService.LogIn(username, password);

            if (authmodel.Message != "")
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = authmodel.Message;
            }
            else
            {
                this.Visible = false;
                new Dashboard(authmodel).Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
