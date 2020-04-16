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
    public partial class Form2 : Form
    {
        public contEntities db = new contEntities();
        public List<s_students> studentsheet;
        public Form2(Form1 f)
        {
            InitializeComponent();
            this.f = f;

            studentsheet = (from st in db.s_students
                            select st).ToList();

        }
        Form1 f;


        private void button1_Click(object sender, EventArgs e) // Найти
        {
            studentsheet = (from st in db.s_students
                            select st).ToList();

            var query = (from st in studentsheet
                         join a in db.s_in_group on st.id_group equals a.id_group
                         orderby st.id
                         select new
                         {
                             st.id,
                             st.surname,
                             st.middlename,
                             a.kurs_num,
                             a.group_num
                         }).ToList();
            if (textBox1.Text != "")
            {
                dataGridView1.DataSource = query.Where(p => p.id.ToString() == textBox1.Text.ToString()).ToList();

            } /* break;
                    case 1:

                        dataGridView1.DataSource = query.Where(p => p.surname.ToString() == textBox1.Text.ToString()).ToList();
                        break;
                    case 2:
                        dataGridView1.DataSource = query.Where(p => p.name.ToString() == textBox1.Text.ToString()).ToList();
                        break;
                    case 3:
                        dataGridView1.DataSource = query.Where(p => p.name_group.ToString() == textBox1.Text.ToString()).ToList();
                        break;

                }
            }
            else
            {
                dataGridView1.DataSource = query;
            }
            dataGridView1.Update();
            if (dataGridView1.RowCount == 0)
                label1.Visible = true;
            else label1.Visible = false;

        } */
        }

        private void button2_Click(object sender, EventArgs e) // Список
        {
            studentsheet = (from st in db.s_students
                            select st).ToList();

            var query = (from st in studentsheet
                         join a in db.s_in_group on st.id_group equals a.id_group
                         orderby st.id
                         select new
                         {
                             st.id,
                             st.surname,
                             st.middlename,
                             a.kurs_num,
                             a.group_num
                         }).ToList();
            dataGridView1.DataSource = query; // DataSource указывает источник данных, из к-го были получены данные эл-та управл-я
            dataGridView1.ReadOnly = true;
            if (dataGridView1.RowCount == 0) label1.Visible = true;
            else label1.Visible = false;

            dataGridView1.Columns[0].HeaderText = "Номер зачетки"; // Измен-е назв-й столбцов
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Номер курса";
            dataGridView1.Columns[5].HeaderText = "Номер группы";
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                Add stadd = new Add();
                stadd.Owner = this;
                stadd.Show();
            }
            else Application.OpenForms[0].Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           /* List<s_students> query = (from st in db.s_students
             select st).ToList();
            if (dataGridView1.SelectedCells.Count == 1)
            {
                if (Application.OpenForms.Count == 2)
                    s_students item = query.First(w => w.code_prog.ToString() ==

             dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                EditPerf perfAdd = new EditPerf(item);
                perfAdd.Owner = this;
                perfAdd.Show();
            }
            else Application.OpenForms[0].Focus(); */ // Не успела
        }


    }
    
    
}

