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
    public partial class BookAbonementView : Form
    {
        BookAbonementViewModel context;

        public BookAbonementView(int clientId)
        {
            context = new BookAbonementViewModel();
            context.ClientId = clientId;
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();

            comboBox3.SelectedIndex = 0;
            comboBox3.DataBindings.Add(new Binding(nameof(comboBox3.SelectedIndex), context, nameof(context.ClassActionTypeIndex), false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void button1_Click(object sender, EventArgs e) // Забронировать 
        {
            if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false
                || checkBox2.Checked == true && checkBox1.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false
                || checkBox3.Checked == true && checkBox2.Checked == false && checkBox1.Checked == false && checkBox4.Checked == false
                || checkBox4.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox1.Checked == false)
            {
                MessageBox.Show($"Вы успешно забронировали абонемент на {comboBox3.SelectedItem} занятия. Для его покупки вам нужно прийти в нашу школу. Ждем вас!");
                context.BookAbonementCommand.Execute(null);
            }
            else
            {
                MessageBox.Show("Можно приобрести только один абонемент. Следущий абонемент доступен к бронированию после окончания действия предыдущего.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Checked)
            {
                context.SelectedCount = 4;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                context.SelectedCount = 8;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                context.SelectedCount = 12;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                context.SelectedCount = 24;
            }
        }
    }
}
