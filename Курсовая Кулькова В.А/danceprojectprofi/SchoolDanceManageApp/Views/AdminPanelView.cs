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
    public partial class AdminPanelView : Form
    {
        AdminPanelViewModel context;
        public AdminPanelView()
        {
            context = new AdminPanelViewModel();
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            
            dataGridView1.ReadOnly = true;    
            dataGridView1.DataBindingComplete += (sender, e) =>
            {
                dataGridView1.Columns[0].HeaderText = "Фамилия клиента";
                dataGridView1.Columns[1].HeaderText = "Имя клиента";
                dataGridView1.Columns[2].HeaderText = "Отчество клиента";
                dataGridView1.Columns[3].HeaderText = "Вид абонемента";
                dataGridView1.Columns[4].HeaderText = "Количество занятий в абонементе";
                dataGridView1.Columns[5].HeaderText = "Количество посещений по абонементу";
                dataGridView1.Columns[6].HeaderText = "Количество индивидуальных разовых занятий";
                dataGridView1.Columns[7].HeaderText = "Количество групповых разовых занятий";
                dataGridView1.Columns[8].HeaderText = "Посещение индивидуальных пробных занятий";
                dataGridView1.Columns[9].HeaderText = "Посещение груповых пробных занятий";
                dataGridView1.Columns[10].HeaderText = "Направление разовых групповых занятий";

                //Скрываем id
                dataGridView1.Columns[11].Visible = false;
            };
            dataGridView1.DataBindings.Add(new Binding(nameof(dataGridView1.DataSource), context, nameof(context.DataSource), false, DataSourceUpdateMode.Never));
        }

        private void button1_Click(object sender, EventArgs e) // Обновить
        {
            context.OnPropertyChanged(nameof(context.DataSource));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                context.OpenClientInformationCommand.Execute(new Tuple<int, bool>((int)dataGridView1[11, e.RowIndex].Value, false));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
