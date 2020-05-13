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
            try
            {
                if (Application.OpenForms.Count == 2)
                {

                    Form7 b = new Form7();
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

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == ',') || (e.KeyChar == ' '))
            {
                e.Handled = true;
                MessageBox.Show("Пожалуйста, для ввода имени используйте только буквы", "Неверный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return;
            }
        }

        private void surnameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void lastnameTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lastnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == ',') || (e.KeyChar == ' '))
            {
                e.Handled = true;
                MessageBox.Show("Пожалуйста, для ввода отчества используйте только буквы", "Неверный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "" )
            {
                MessageBox.Show("Введите имя автора!");
            }
        }
    }
}
