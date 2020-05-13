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
    public partial class Form1 : Form
    {
        public demoEntities db = new demoEntities();// новый объект типа demoEntities
        public List<students> studentsheet; // список из объектов, соответ-ий соед-ю табл students и groups в БД
        public Form1()
        {
            InitializeComponent();

            studentsheet = (from stud in db.students // определяем каждый объект из students как stud
                            select stud).ToList(); // выбираем объект и передает выбр-е знач-я в результи-ую выборку
            var query = (from stud in studentsheet
                         join g in db.groups on stud.code_group equals g.code_group
                         orderby stud.code_stud
                         select new
                         {
                             stud.code_stud,
                             stud.surname,
                             stud.name,
                             g.name_group,
                             stud.code_group
                         }).ToList();
            dataGridView1.DataSource = query; // DataSource указывает источник данных, из к-го были получены данные эл-та управл-я
            dataGridView1.ReadOnly = true;
            if (dataGridView1.RowCount == 0) label1.Visible = true;
            else label1.Visible = false;

            dataGridView1.Columns[0].HeaderText = "Номер студента"; // Измен-е назв-й столбцов
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Номер группы";
            dataGridView1.Columns[4].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e) //Поиск
        {
            try
            {
                studentsheet = (from stud in db.students
                                select stud).ToList();
                var query = (from stud in studentsheet
                             join g in db.groups on stud.code_group equals g.code_group
                             orderby stud.code_stud
                             select new
                             {
                                 stud.code_stud,
                                 stud.surname,
                                 stud.name,
                                 g.name_group,
                                 stud.code_group
                             }).ToList();
                if (textBox1.Text != "")
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            dataGridView1.DataSource = query.Where(p => p.code_stud.ToString() == textBox1.Text.ToString()).ToList();
                            break;
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
            }
            catch(Exception)
            {
                MessageBox.Show(text: "Неверный ввод данных", caption: "Ошибка");
            }

        }

        private void button3_Click(object sender, EventArgs e) // Добавить
        {
            try
            {
                if (Application.OpenForms.Count == 2)
                {
                    FormAddStudent addSt = new FormAddStudent();
                    addSt.Owner = this;
                    addSt.ShowDialog();
                    this.Hide();
                    this.Close();
                }
                else Application.OpenForms[0].Focus();
            }
                
                catch (Exception)
            {
                MessageBox.Show(text: "Ошибка с подлючением БД", caption: "Ошибка");
            }
        }
        private void button4_Click(object sender, EventArgs e) //Обновить
        {
            var query = (from stud in db.students
                         join g in db.groups on stud.code_group equals g.code_group
                         orderby stud.code_stud
                         select new
                         {
                             stud.code_stud,
                             stud.surname,
                             stud.name,
                             g.name_group,
                             stud.code_group
                         }).ToList();
            dataGridView1.DataSource = query;
            label1.Visible= false;
        }

        private void button2_Click(object sender, EventArgs e) // Редактировать
        {
            try
            {
                List<students> query = (from stud in db.students select stud).ToList();
                if (dataGridView1.SelectedCells.Count == 1)
                {
                    if (Application.OpenForms.Count == 2)

                    {
                        students item = query.First(w => w.code_stud.ToString() ==

                      dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                        FormEditStudent editSt = new FormEditStudent(item);
                        editSt.Owner = this;
                        editSt.ShowDialog(); 
                        this.Hide();
                        this.Close();
                    }
                    else Application.OpenForms[0].Focus();
                }
            }
            catch(Exception)
            {
                MessageBox.Show(text: "Ошибка с подлючением БД", caption: "Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e) // Экспорт
        {
            SaveFileDialog dialog = new SaveFileDialog(); // создается новое диалоговое окно SaveFileDialog dialog
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.DefaultExt = ".xls";

            dialog.Filter = "Таблицы Excel (*.xls)|.xls|Все файлы(*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.FileName = "Отчет";


            var query = (from stud in db.students
                         join g in db.groups on stud.code_group equals g.code_group
                         orderby stud.code_stud
                         select new { stud.code_stud, stud.surname, stud.name, g.name_group, stud.code_group }).ToList();

            var template = new MemoryStream(Properties.Resources.template, true);
            var workbook = new XSSFWorkbook(template);   // создается новая рабочая книга   
            var sheet1 = workbook.GetSheet("Лист1");   // XSSFWorkbook workbook на основе шаблона.
            int row = 11; // объявл-е переменной; нач-е знач будет соответ-ть №строки,с которой необходимо вставить данные в таблицу. 
            foreach (var item in query.OrderBy(o => o.code_stud))
            {
                var rowInsert = sheet1.CreateRow(row);
                rowInsert.CreateCell(1).SetCellValue(item.code_stud);
                rowInsert.CreateCell(2).SetCellValue(item.surname);
                rowInsert.CreateCell(3).SetCellValue(item.name);
                rowInsert.CreateCell(4).SetCellValue(Convert.ToInt32(item.name_group));
                row++;
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var file = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                workbook.Write(file);
            }

        }
       
        private void button6_Click_1(object sender, EventArgs e) // Удалить
        { 
            try
            {
                DialogResult result;
                result = MessageBox.Show("Вы действительно хотите удалить?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    List<students> query = (from stud in db.students
                                            select stud).ToList();

                    if (dataGridView1.SelectedCells.Count == 1)
                    {

                        students item = query.First(w => w.code_stud.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                        db.students.Remove(item);
                        db.SaveChanges();
                        MessageBox.Show("Удалено");
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show(text: "Ошибка с подлючением БД", caption: "Ошибка");
            }
        }
        
    }
}
