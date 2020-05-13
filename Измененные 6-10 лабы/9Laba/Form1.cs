using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9Laba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.Count == 1)
                {
                    Form2 a = new Form2();
                    a.Show();
                }
                else Application.OpenForms[0].Focus();
            }
            catch (Exception)
            {
                MessageBox.Show(text: "Проблема с подключенем к БД", caption: "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.Count == 1)
                {
                    Form3 a = new Form3();
                    a.Show();
                }
                else Application.OpenForms[0].Focus();
            }
            catch (Exception)
            {
                MessageBox.Show(text: "Проблема с подключенем к БД", caption: "Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try 
            { 
            if (Application.OpenForms.Count == 1)
            {
                Form4 a = new Form4();
                a.Show();
            }
            else Application.OpenForms[0].Focus();
        }
            catch (Exception)
            {
                MessageBox.Show(text: "Проблема с подключенем к БД", caption: "Ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.Count == 1)
                {
                    Form5 a = new Form5();
                    a.Show();
                }
                else Application.OpenForms[0].Focus(); }
            catch (Exception)
            {
                MessageBox.Show(text: "Проблема с подключенем к БД", caption: "Ошибка");
            }
        }
    }
}
