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
    public partial class Add : Form
    {
        public contEntities db = new contEntities();
        public Add()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int number_of_group = db.s_in_group.Max(n => n.id_group) + 1;
            s_in_group qr = new s_in_group
            {

                id_group = number_of_group,
                group_num = int.Parse(textBox1.Text),
               
            };
                db.s_in_group.Add(qr);
            db.SaveChanges();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы хотите закрыть окно?", "Окно отмены", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                return;
            }
        }
    }
}
