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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bOOKSDataSet.books". При необходимости она может быть перемещена или удалена.
            this.booksTableAdapter.Fill(this.bOOKSDataSet.books);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewColumn Col = namebookDataGridViewTextBoxColumn1; //создаёт переменную Col для хранения имени выбранного столбца таблицы;
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    Col = namebookDataGridViewTextBoxColumn1;
                    break;
                case 1:
                    Col = yearbookDataGridViewTextBoxColumn2;
                    break;
            }
            if(radioButton1.Checked)
            {
                dataGridView1.Sort(Col, ListSortDirection.Ascending);
            }
            else
            {
                dataGridView1.Sort(Col, ListSortDirection.Descending);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            booksBindingSource.Filter = "Name_book='" + comboBox1.Text + "'";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            booksBindingSource.Filter = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < (dataGridView1.RowCount - 1); i++)
            {
                for (int j = 0; j < (dataGridView1.ColumnCount); j++)

                {
                    DataGridViewCell cell = dataGridView1.Rows[i].Cells[j];
                    cell.Style.BackColor = Color.White;
                    cell.Style.ForeColor = Color.Black;

                }
            }
            for (int i = 0; i < (dataGridView1.RowCount - 1);  i++)
            {
                for (int j = 0; j < (dataGridView1.ColumnCount); j++)
                {
                    DataGridViewCell cell = dataGridView1.Rows[i].Cells[j];
                    if (cell.Value.Equals(textBox1.Text))
                    {
                        cell.Style.BackColor = Color.AliceBlue;
                        cell.Style.ForeColor = Color.Blue;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
