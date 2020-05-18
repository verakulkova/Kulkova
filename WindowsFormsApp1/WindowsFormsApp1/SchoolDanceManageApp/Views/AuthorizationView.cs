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
    public partial class AuthorizationView : Form
    {
        AuthorizationViewModel context;
        public AuthorizationView(AuthType authType)
        {
            context = new AuthorizationViewModel();
            context.AuthType = authType;
            context.RequestClose = () => Close();
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            label1.DataBindings.Add(new Binding(nameof(label1.Text), context, nameof(context.Label), false, DataSourceUpdateMode.Never));
            textBox1.DataBindings.Add(new Binding(nameof(textBox1.Text), context, nameof(context.Login), false, DataSourceUpdateMode.OnPropertyChanged));
            textBox2.DataBindings.Add(new Binding(nameof(textBox2.Text), context, nameof(context.Password), false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO Здесь передавать регистрационные данные
            context.LoginCommand.Execute(null);
        }
    }
}
