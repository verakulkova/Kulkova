using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6Лаба
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
                User u1 = new User();
                u1.GetName(textBox1.Text, textBox2.Text);
                if (u1.b1)
                {
                    if (Application.OpenForms.Count == 1)

                    {
                        Form2 newForm = new Form2(this);
                        this.Hide();
                        newForm.Show();  //Dialog();
                        newForm.Text = u1.Name;
                    }
                    else Application.OpenForms[0].Focus();
                }
            }
            catch(Exception)
            {
                MessageBox.Show(text: "Неверный ввод данных",caption: "Ошибка");
            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы хотите закрыть окно входа?", "Окно отмены", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                    //return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(text: "Ошибка с введенными данными", caption: "Ошибка");
            }

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Для ввода пароля не используются пробелы", "Неверный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return;
            }
        }
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("Для ввода логина не используются пробелы", "Неверный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
