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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void authorsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.authorsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bOOKSDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bOOKSDataSet.authors". При необходимости она может быть перемещена или удалена.
            this.authorsTableAdapter.Fill(this.bOOKSDataSet.authors);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 b = new Form7();
            b.Show();
        }
    }
}
