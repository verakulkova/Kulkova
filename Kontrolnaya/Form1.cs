using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontrolnaya
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent(); 
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            u1.GetName(textBox1.Text, textBox2.Text);
            if (u1.b1)
            {
                Form2 f2 = new Form2(this);
                f2.Show();
                f2.Text = u1.Name;
            }
        }
    }
}
