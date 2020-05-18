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
    public partial class SignUpForClassView : Form
    {
        SignUpForClassViewModel context;
        public SignUpForClassView(ClassType classType)
        {
            context = new SignUpForClassViewModel();
            context.ClassType = classType;
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text != "" && dateTimePicker2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                MessageBox.Show($"Вы записаны на {(context.ClassType == ClassType.Test ? "бесплатное пробное" : "разовое")}  " + comboBox3.Text + $" занятие. {(context.ClassType == ClassType.Test ? "Оно доступно только один раз." : "")} Ждем вас в нашей школе!");
            }

            else { MessageBox.Show("Пожалуйста, заполните все поля."); }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "индивидуальное")
            {
                comboBox4.Enabled = false;
            }
            else { comboBox4.Enabled = true; }

            if (comboBox3.Text == "групповое")
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите выйти?", "Окно отмены", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                return;
            }
        }
    }
}