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
        public Form2()
        {
            InitializeComponent();
            
        }
        public Form2(Form1 form)
        {
            InitializeComponent();
            this.form = this.form;
            
        }

        Form1 form;
        private void Form2_Shown(object sender, EventArgs e)

            {
                this.textBox1.Text = form.textBox1.Text;
                this.textBox2.Text = form.textBox2.Text;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            u1.ChangeData(textBox1.Text, textBox2.Text, this.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Close();
        }
    }
    }

