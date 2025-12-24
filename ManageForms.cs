using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PointixApp
{
    public class ManageForms : ApplicationContext
    {
        private static ManageForms _instance;
        private Form _currentForm;

        public static ManageForms Instance => _instance ?? (_instance = new ManageForms());

        private ManageForms() { }

        public void ShowForm(Form form)
        {
            if (_currentForm != null)
            {
                _currentForm.FormClosing -= OnFormClosing;
                _currentForm.Close();
            }

            _currentForm = form;
            _currentForm.FormClosing += OnFormClosing;
            _currentForm.Show();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}