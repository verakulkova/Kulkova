using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8Laba
{
    public partial class FormEditStudent : Form
    {
        public demoEntities db = new demoEntities();
        students item;
        public FormEditStudent(students stud)
        {
            item = stud;
            InitializeComponent();
            var group_for_list = (from g in db.groups
                                  select g.name_group).Distinct();
            foreach (string it in group_for_list)
            {
                comboBox1.Items.Add(it);

            }
            textBox1.Text = item.surname.ToString();
            textBox2.Text = item.name.ToString();
            var query = (from g in db.groups
                         where g.code_group == item.code_group
                         select g.name_group).ToList();
            comboBox1.SelectedItem = query[0];

        }

        private void button3_Click(object sender, EventArgs e) //Редактировать
        {
            try
            {
                if (textBox2.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Введите имя!");
                }
                var result = ((Form1)Owner).db.students.SingleOrDefault(w => w.code_stud == item.code_stud);
                result.surname = textBox1.Text.ToString();
                result.name = textBox2.Text.ToString();
                var query = (from g in db.groups
                             where g.name_group == comboBox1.SelectedItem.ToString()
                             select g.code_group).ToList();
                result.code_group = query[0];
                ((Form1)Owner).studentsheet = ((Form1)Owner).db.students.OrderBy(o => o.code_stud).ToList();
                ((Form1)Owner).db.SaveChanges();
                MessageBox.Show("Изменения сохранены. Вы можете вернутсья на старницу меню или закрыть приложение.");
                this.Close();
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(text: "Нельзя оставлять пустые строки", caption: "Ошибка");
            }
            
        }


        private void button2_Click(object sender, EventArgs e) // Отмена
        {
            if (MessageBox.Show("Вы хотите закрыть окно редактирования?", "Окно отмены", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                return;

            }
        }
    private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
    {

        if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == ',') || (e.KeyChar == ' '))
        {
            e.Handled = true;
            MessageBox.Show("Пожалуйста, для ввода имени используйте буквы", "Неверный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            return;
        }
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == ',') || (e.KeyChar == ' '))
        {
            e.Handled = true;
            MessageBox.Show("Пожалуйста, для ввода фамилии используйте только буквы", "Неверный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            return;
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (comboBox1.Text.Length == 0)
        {
            button3.Enabled = false;
        }
        else
        {
            button3.Enabled = true;
        }
        
    }
}
}

    


           
        

