using PointixApp.Controller;
using PointixApp.DataLayer;
using PointixApp.Forms;
using PointixApp.Patterns;
using PointixApp.Properties;
using PointixApp.Services;
using System.ComponentModel;
using System.Windows.Forms;

namespace PointixApp
{
    public partial class LogInForm : Form
    {

        private Mediator mediator;
        private AppDbContext context;

        public LogInForm()
        {
            InitializeComponent();

        }
        public LogInForm(AppDbContext _context, IAuthService _authService)
        {
            InitializeComponent();
            this.context = _context;
            this.mediator = new Mediator(context);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = UserNameField.Text;
            string password = PasswordField.Text;

            var authmodel = mediator.authService.LogIn(username, password);

            if (authmodel.Message != "")
            {
                MessageBox.Show(authmodel.Message);
            }
            else
            {
                ManageLanguages.Language = radioButton1.Checked ? "ar" : "en";
                Dashboard dashboard = new Dashboard(authmodel, context);
                ManageForms.Instance.ShowForm(dashboard);
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.DrawPointixLogo(e.Graphics, 439, 177);
        }
    }
}
