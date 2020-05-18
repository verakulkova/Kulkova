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

        public BookAbonementView()
        {
            context = new BookAbonementViewModel();
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Забронировать 
        {
            if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false
                || checkBox2.Checked == true && checkBox1.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false
                || checkBox3.Checked == true && checkBox2.Checked == false && checkBox1.Checked == false && checkBox4.Checked == false
                || checkBox4.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox1.Checked == false)
            {
                MessageBox.Show($"Вы успешно забронировали абонемент на {comboBox3.SelectedItem} занятия. Для его покупки вам нужно прийти в нашу школу. Ждем вас!");
            }
            else
            {
                MessageBox.Show("Можно приобрести только один абонемент. Следущий абонемент доступен к бронированию после окончания действия предыдущего.");
            }
        }
    }
}
