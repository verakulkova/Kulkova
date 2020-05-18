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
    public partial class PrivateOfficeView : Form
    {
        PrivateOfficeViewModel context;
        public PrivateOfficeView(int clientId)
        {
            context = new PrivateOfficeViewModel();
            context.ClientId = clientId;
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e) // Расписание
        {
            context.OpenTimetableCommand.Execute(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ЛичныйКабинетКлиента_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // Направления
        {
            context.OpenDirectionsCommand.Execute(null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            context.OpenClientInfoCommand.Execute(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            context.OpenBookingCommand.Execute(null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            context.OpenSignUpForClassCommand.Execute(ClassType.Single);
        }

        private void button7_Click(object sender, EventArgs e)  // Пробное
        {
            context.OpenSignUpForClassCommand.Execute(ClassType.Test);
        }

        private void button6_Click(object sender, EventArgs e)
        {
             String openPDFFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\HelpDoc.pdf";
            System.IO.File.WriteAllBytes(openPDFFile, global::SchoolDanceManageApp.Properties.Resources.Справка2);
            System.Diagnostics.Process.Start(openPDFFile); 
        }
    }
}
