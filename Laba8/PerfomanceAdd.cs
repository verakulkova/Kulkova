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
    public partial class PerfomanceAdd : Form
    {
        public demoEntities db = new demoEntities();
        public PerfomanceAdd()
        {
           InitializeComponent();
            var pp = (from perf in db.lectors
                        select perf.name_lector).Distinct();
            foreach (string it in pp)
            {
                
                comboBox4.Items.Add(it);
            }
            
        }
        private void button1_Click(object sender, EventArgs e) // Добавить
        {
          
            var query3 = (from kk in db.lectors
                         where kk.name_lector == comboBox4.SelectedItem.ToString()
                         select kk.code_lector).ToList();
            int number_of_student = db.students.Max(n => n.code_stud) + 1;

            progress new_progress = new progress
            {
                code_stud = number_of_student,
                
            };
            db.progress.Add(new_progress);
            db.SaveChanges();
            this.Close();     }



        private void button2_Click(object sender, EventArgs e) // Отмена
        {
            if (MessageBox.Show("Вы действительно хотите закрыть окно?", "Окно отмены", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                return;
            }

        }
    }
}
