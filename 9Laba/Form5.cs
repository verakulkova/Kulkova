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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void publishBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.publishBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bOOKSDataSet);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bOOKSDataSet.sales". При необходимости она может быть перемещена или удалена.
            this.salesTableAdapter.Fill(this.bOOKSDataSet.sales);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bOOKSDataSet.publish". При необходимости она может быть перемещена или удалена.
            this.publishTableAdapter.Fill(this.bOOKSDataSet.publish);

        }
    }
}
