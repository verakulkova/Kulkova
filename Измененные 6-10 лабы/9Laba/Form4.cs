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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void publisherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.publisherBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bOOKSDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bOOKSDataSet.publisher". При необходимости она может быть перемещена или удалена.
            this.publisherTableAdapter.Fill(this.bOOKSDataSet.publisher);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (name_publisherTextBox.Text == "" || city_publisherTextBox.Text == "")
            {
                MessageBox.Show("Введите название книги!");
            }
        }
    }
}
