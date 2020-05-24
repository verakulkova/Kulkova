using SchoolDanceManageApp.Misc;
using SchoolDanceManageApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDanceManageApp.Views
{
    public partial class TimetableView : Form
    {
        TimetableViewModel context;
        public TimetableView()
        {
            context = new TimetableViewModel();
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataBindingComplete += (sender, e) =>
            {
                dataGridView1.Columns[0].HeaderText = "Время";
                dataGridView1.Columns[1].HeaderText = "Направление";
                dataGridView1.Columns[2].HeaderText = "Фамилия преподавателя";
                dataGridView1.Columns[3].HeaderText = "Имя преподавателя";
                dataGridView1.Columns[4].HeaderText = "Отчество преподавателя";
            };

            dataGridView1.DataBindings.Add(new Binding(nameof(dataGridView1.DataSource), context, nameof(context.DataSource), false, DataSourceUpdateMode.Never));

            textBox1.DataBindings.Add(new Binding(nameof(textBox1.Text), context, nameof(context.DirectionFilter), false, DataSourceUpdateMode.OnPropertyChanged));
            textBox2.DataBindings.Add(new Binding(nameof(textBox2.Text), context, nameof(context.SurnameFilter), false, DataSourceUpdateMode.OnPropertyChanged));
            textBox3.DataBindings.Add(new Binding(nameof(textBox3.Text), context, nameof(context.FirstNameFilter), false, DataSourceUpdateMode.OnPropertyChanged));

            checkBox1.DataBindings.Add(new Binding(nameof(checkBox1.Checked), context, nameof(context.DateFilterEnabled), false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePicker1.DataBindings.Add(new Binding(nameof(dateTimePicker1.Enabled), context, nameof(context.DateFilterEnabled), false, DataSourceUpdateMode.Never));
            dateTimePicker1.DataBindings.Add(new Binding(nameof(dateTimePicker1.Value), context, nameof(context.DateFilter), false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}
