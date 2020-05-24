using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDanceManageApp.Misc
{
    /// <summary>
    /// 
    /// </summary>
    static class Navigation
    {
        static Form main;
        static Navigation()
        {
            main = Application.OpenForms[0];
        }

        public static void Open(Form form)
        {
            form.FormClosed += (sender, e) =>
            {
                if (Application.OpenForms.Count == 1)
                {
                    main.Enabled = true;
                }
            };

            main.Enabled = false;

            form.Show();
        }

        public static void OpenDialog(Form form)
        {
            form.ShowDialog();
        }
    }
}
