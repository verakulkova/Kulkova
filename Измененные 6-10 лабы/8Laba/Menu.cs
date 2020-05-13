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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // Успеваемость 
        {
            {

               if ((Application.OpenForms.Count == 1 ) || (Application.OpenForms.Count == 2))
                {
                    AcademicPerformance academ = new AcademicPerformance();
                    academ.Owner = this;
                    academ.Show(); // Dialog();//Форма с меню должна быть открыта ,чтобы иметь возможность открыть форму Список учеников
                                   //this.Hide();
                                   // this.Close();
                }
                else Application.OpenForms[0].Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e) // Список студентов
        {
            if (Application.OpenForms.Count == 1 || Application.OpenForms.Count == 2)
            {
                Form1 f = new Form1();
                f.Owner = this;
                f.Show(); // Dialog();
                //this.Hide();  //Форма с меню должна быть открыта ,чтобы иметь возможность открыть форму Успеваемости
                //this.Close();
            }
            else Application.OpenForms[0].Focus();
        }
    }
}
