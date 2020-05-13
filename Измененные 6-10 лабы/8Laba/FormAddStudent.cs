using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _8Laba
{

    public partial class FormAddStudent : Form
    {
        public demoEntities db = new demoEntities();
        public FormAddStudent()
        {

            InitializeComponent();
            var groups_for_list = (from g in db.groups
                                   select g.name_group).Distinct();
            foreach (string it in groups_for_list)
            {
                comboBox1.Items.Add(it);
            }

        }

        private void button1_Click(object sender, EventArgs e) // Добавить
        {
            try
            {
                if (textBox2.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Введите имя и группу!");
                }
                var query = (from g in db.groups
                             where g.name_group == comboBox1.SelectedItem.ToString()
                             select g.code_group).ToList();
                int number_of_student = db.students.Max(n => n.code_stud) + 1;
                
                students new_student = new students
                {
                    code_stud = number_of_student,
                    surname = textBox1.Text,
                    name = textBox2.Text,
                    code_group = query[0]
                };
                db.students.Add(new_student);
                db.SaveChanges();
                MessageBox.Show("Студент добавлен. Вы можете вернутсья на старницу меню или закрыть приложение."); 
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(text:"Нельзя добавлять пустые строки", caption: "Ошибка");
            }

        }
        private void button2_Click(object sender, EventArgs e) // Отмена
        {

            if (MessageBox.Show("Вы хотите закрыть окно добавление студента?", "Окно отмены", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
