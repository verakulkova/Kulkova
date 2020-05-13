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
    public partial class Form2 : Form
    {
        public Form2(Form1 ff)
        {
            InitializeComponent();
            this.ff = ff;
        }

        Form1 ff;
        private void Form2_Shown(object sender, EventArgs e)

            {
                this.textBox1.Text = ff.textBox1.Text;
                this.textBox2.Text = ff.textBox2.Text;
            }

        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (textBox2.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    User u1 = new User();
                    u1.ChangeData(textBox1.Text, textBox2.Text, this.Text);
                    MessageBox.Show("Изменения сохранены");
                    this.Close();
                    ff.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show(text: "Неверный ввод данных", caption: "Ошибка");
            }
        }
    private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                ff.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(text: "Был неверный ввод данных", caption: "Ошибка");
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
    }
    }

