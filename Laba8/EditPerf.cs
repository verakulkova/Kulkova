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
    public partial class EditPerf : Form
    {
        public demoEntities db = new demoEntities();
        progress item;
        public EditPerf(progress prog)
        {
            item = prog;
            InitializeComponent();
            var pp = (from perf in db.progress
                        select perf.estimate).Distinct();
            foreach (int it in pp)
            {

                comboBox1.Items.Add(it);
            }
            var query = (from perf in db.progress
                         where perf.code_prog == item.code_prog
                         select perf.estimate).ToList();
            comboBox1.SelectedItem = query[0];

        }
        private void button1_Click(object sender, EventArgs e) // Редактировать
        {
           
            var result = ((AcademicPerformance)Owner).db.progress.SingleOrDefault(w => w.code_prog == item.code_prog);
            var query = (from perf in db.progress
                         where perf.estimate == item.code_prog
                         select perf.code_prog).ToList();
            result.code_prog = query[0];
            ((AcademicPerformance)Owner).progressheet = ((AcademicPerformance)Owner).db.progress.ToList();
            this.Close();
            MessageBox.Show("Изменения сохранены");

        }

        private void button2_Click(object sender, EventArgs e) // Отмена
        {
            if (MessageBox.Show("Вы хотите закрыть окно?", "Окно отмены", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                return;
            }
        }
    }
}
