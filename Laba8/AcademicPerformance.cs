using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NPOI.XSSF.UserModel;

namespace _8Laba
{
    public partial class AcademicPerformance : Form
    {
        public demoEntities db = new demoEntities();
        public List<progress> progressheet;
        public AcademicPerformance()
        {
           
            InitializeComponent();
            progressheet = (from pr in db.progress // определяем каждый объект из progress как pr
                            select pr).ToList();
        
            var query = (from pr in db.progress
                         join a in db.students on pr.code_stud equals a.code_stud
                         join b in db.subjects on pr.code_subject equals b.code_subject
                         join c in db.lectors on pr.code_lector equals c.code_lector
                         join d in db.groups on a.code_group equals d.code_group
                         orderby pr.code_stud
                         select new
                         {
                             a.surname,
                             a.name,
                             d.name_group,
                             b.name_subject,
                             c.name_lector,
                             pr.date_exam,
                             pr.estimate,   
                         }).ToList();
            comboBox1.SelectedItem = query[0];
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
            if (dataGridView1.RowCount == 0) label1.Visible = true;
            else label1.Visible = false;
            dataGridView1.Columns[0].HeaderText = "Фамилия студента"; 
            dataGridView1.Columns[1].HeaderText = "Имя студента";
            dataGridView1.Columns[2].HeaderText = "Группа";
            dataGridView1.Columns[3].HeaderText = "Дисциплина";
            dataGridView1.Columns[4].HeaderText = "Преподаватель";
            dataGridView1.Columns[5].HeaderText = "Дата экзамена";
            dataGridView1.Columns[6].HeaderText = "Оценка";
        }
        private void button1_Click(object sender, EventArgs e) // Поиск
        {
            progressheet = (from pr in db.progress
                            select pr).ToList();
            var query = (from pr in db.progress
                         join a in db.students on pr.code_stud equals a.code_stud
                         join b in db.subjects on pr.code_subject equals b.code_subject
                         join c in db.lectors on pr.code_lector equals c.code_lector
                         join d in db.groups on a.code_group equals d.code_group
                         orderby pr.code_stud
                         select new
                         {
                             a.surname,
                             a.name,
                             b.name_subject,
                             c.name_lector,
                             d.name_group,
                             pr.date_exam,
                             pr.estimate,
                         }).ToList();
            if (textBox1.Text != "")
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        dataGridView1.DataSource = query.Where(s => s.name.ToString() == textBox1.Text.ToString()).ToList();
                        break;
                    case 1:

                        dataGridView1.DataSource = query.Where(s => s.name_subject.ToString() == textBox1.Text.ToString()).ToList();
                        break;
                    case 2:
                        dataGridView1.DataSource = query.Where(s => s.name_lector.ToString() == textBox1.Text.ToString()).ToList();
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

        }

        private void button2_Click(object sender, EventArgs e) // Редкатировать
        {
            List<progress> query = (from pr in db.progress
                                    select pr).ToList();
            if (dataGridView1.SelectedCells.Count == 1)
            {
                if (Application.OpenForms.Count == 2)
                {
                    progress item = query.First(w => w.code_prog.ToString() ==

              dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                   EditPerf perfAdd = new EditPerf(item);
                    perfAdd.Owner = this;
                    perfAdd.Show();
                }
                else Application.OpenForms[0].Focus();
            }
            
        }

        private void button3_Click(object sender, EventArgs e) // Добавить
        {
            {
                if (Application.OpenForms.Count == 2)
                {
                    List<progress> query = (from pr in db.progress
                                            select pr).ToList();
                    if (dataGridView1.SelectedCells.Count == 1)
                    {
                        if (Application.OpenForms.Count == 2)
                        {
                            progress item = query.First(w => w.code_prog.ToString() ==

                      dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                            PerfomanceAdd perfAdd = new PerfomanceAdd();
                            perfAdd.Owner = this;
                            perfAdd.Show();
                        }
                        else Application.OpenForms[0].Focus();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /* var delete = (from pr in db.progress
                          join a in pr.code_stud
                           select pr).FirstOrDefault();
            db.progress.Remove(delete);
            db.SaveChanges(); */
        }

        private void button5_Click(object sender, EventArgs e) // Экспорт
        {
            SaveFileDialog dialog = new SaveFileDialog(); // создается новое диалоговое окно SaveFileDialog dialog
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.DefaultExt = ".xls";

            dialog.Filter = "Таблицы Excel (*.xls)|.xls|Все файлы(*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.FileName = "Отчет1";


            var query = (from pr in db.progress
                         join a in db.students on pr.code_stud equals a.code_stud
                         join b in db.subjects on pr.code_subject equals b.code_subject
                         join c in db.lectors on pr.code_lector equals c.code_lector
                         join d in db.groups on a.code_group equals d.code_group
                         orderby pr.code_stud
                         select new
                         {
                             a.surname,
                             a.name,
                             d.name_group,
                             b.name_subject,
                             c.name_lector,
                             pr.date_exam,
                             pr.estimate,
                         }).ToList();

            var template1 = new MemoryStream(Properties.Resources.template, true);
            var workbook = new XSSFWorkbook(template1);   // создается новая рабочая книга   
            var sheet1 = workbook.GetSheet("Лист1");   // XSSFWorkbook workbook на основе шаблона.
            int row = 12; // объявл-е переменной; нач-е знач будет соответ-ть №строки,с которой необходимо вставить данные в таблицу. 
            foreach (var item in query.OrderBy(o => o.surname))
            {
                var rowInsert = sheet1.CreateRow(row);
                rowInsert.CreateCell(1).SetCellValue(item.surname);
                rowInsert.CreateCell(2).SetCellValue(item.name);
                rowInsert.CreateCell(3).SetCellValue(item.name_group);
                rowInsert.CreateCell(4).SetCellValue(item.name_lector);
                rowInsert.CreateCell(4).SetCellValue(item.name_subject);
                rowInsert.CreateCell(5).SetCellValue(item.date_exam);
                rowInsert.CreateCell(6).SetCellValue((double)item.estimate);
                row++;
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var file = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                workbook.Write(file);
            }

        }
    }
}

