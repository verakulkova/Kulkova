﻿using SchoolDanceManageApp.Misc;
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
            textBox2.DataBindings.Add(new Binding(nameof(textBox2.Text), context, nameof(context.Password), false, DataSourceUpdateMode.OnPropertyChanged));
            textBox1.DataBindings.Add(new Binding(nameof(textBox1.Text), context, nameof(context.Login), false, DataSourceUpdateMode.OnPropertyChanged));
            textBox5.DataBindings.Add(new Binding(nameof(textBox5.Text), context, nameof(context.Surname), false, DataSourceUpdateMode.OnPropertyChanged));
            textBox4.DataBindings.Add(new Binding(nameof(textBox4.Text), context, nameof(context.Name), false, DataSourceUpdateMode.OnPropertyChanged));

            label4.Enabled = label4.Visible = authType == AuthType.SignUp;
            textBox4.Enabled = textBox4.Visible = authType == AuthType.SignUp;
            label5.Enabled = label5.Visible = authType == AuthType.SignUp;
            textBox5.Enabled = textBox5.Visible = authType == AuthType.SignUp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //TODO Здесь передавать регистрационные данные
            context.LoginCommand.Execute(null);
        }
    }
}
