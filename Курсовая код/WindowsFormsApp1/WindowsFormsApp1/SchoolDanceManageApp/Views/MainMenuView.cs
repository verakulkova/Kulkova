using SchoolDanceManageApp.Misc;
using SchoolDanceManageApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDanceManageApp.Views
{
    public partial class MainMenuView : Form
    {
        private MainMenuViewModel context;

        public MainMenuView()
        {
            context = new MainMenuViewModel();
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            context.OpenAuthCommand.Execute(AuthType.SignUp);
        }

        private void authButton_Click(object sender, EventArgs e)
        {
            context.OpenAuthCommand.Execute(AuthType.SignIn);
        }

        private void openTimetableButton_Click(object sender, EventArgs e)
        {
            context.OpenTimetableCommand.Execute(null);
        }

        private void openDirectionsButton_Click(object sender, EventArgs e)
        {
            context.OpenDirectionsCommand.Execute(null);
        }

        private void button5_Click(object sender, EventArgs e) // Сравка
        {
            String openPDFFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\HelpDoc.pdf";
            System.IO.File.WriteAllBytes(openPDFFile, global::SchoolDanceManageApp.Properties.Resources.Справка);
            System.Diagnostics.Process.Start(openPDFFile);
        }
    }
}
