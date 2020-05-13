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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void booksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.booksBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bOOKSDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bOOKSDataSet.books". При необходимости она может быть перемещена или удалена.
            this.booksTableAdapter.Fill(this.bOOKSDataSet.books);

        }

        private void button1_Click(object sender, EventArgs e) // Таблица
        {
            try
            {
                if (Application.OpenForms.Count == 2)
                {
                    Form6 b = new Form6();
                    b.Show();
                }
                else { Application.OpenForms[0].Focus(); }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(text: "Проблема с подключенем к БД", caption: "Ошибка");
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (name_bookTextBox.Text == "" )
            {
                MessageBox.Show("Введите название книги!");
            }
        }
    }
}
