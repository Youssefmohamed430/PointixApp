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

namespace PointixApp
{
    public partial class Dashboard : Form
    {
        private AuthModel _authModel;
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(AuthModel authModel)
        {
            InitializeComponent();
            this._authModel = authModel;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
