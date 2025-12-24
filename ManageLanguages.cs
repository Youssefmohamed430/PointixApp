using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp
{
    public static class ManageLanguages
    {
        public static string Language ; 
        public static void EquipLanguage(Form form)
        {
            switch (Language)
            {
                case "en":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    break;
                case "ar":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-EG");
                    break;
            }
        }
    }
}
