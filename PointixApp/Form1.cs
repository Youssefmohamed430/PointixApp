using PointixApp.Properties;
using System.ComponentModel;

namespace PointixApp
{
    public partial class LogInForm : Form
    {
        private ComponentResourceManager resources = new ComponentResourceManager(typeof(LogInForm));
        public LogInForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadResources();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void LoadResources()
        {
            string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang == "ar" ? "ar" : "en");
            resources = new ComponentResourceManager(typeof(LogInForm)); // إعادة تهيئة الموارد
            resources.ApplyResources(this, "$this");
            ApplyResources(this);
        }

        private void ApplyResources(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                resources.ApplyResources(c, c.Name);
                ApplyResources(c);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "ar" ? "en" : "ar";
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            LoadResources();
        }

        private void UserNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
