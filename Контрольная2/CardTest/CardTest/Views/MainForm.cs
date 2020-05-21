using CardTest.Misc;
using CardTest.Properties;
using CardTest.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardTest.Views
{
    public partial class MainForm : Form
    {
        MainFormViewModel context;
        public MainForm()
        {
            context = new MainFormViewModel();
            InitializeComponent();

            textBox1.DataBindings.Add(new Binding(nameof(textBox1.Text), context, nameof(context.Name), false, DataSourceUpdateMode.OnPropertyChanged));
            textBox2.DataBindings.Add(new Binding(nameof(textBox2.Text), context, nameof(context.Email), false, DataSourceUpdateMode.OnPropertyChanged));

            textBox3.DataBindings.Add(new Binding(nameof(textBox3.Text), context, nameof(context.EmailSender), false, DataSourceUpdateMode.OnPropertyChanged));
            textBox4.DataBindings.Add(new Binding(nameof(textBox4.Text), context, nameof(context.NameSender), false, DataSourceUpdateMode.OnPropertyChanged));
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = context.SelectedImage;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                context.SelectedImage = Resources.tiger;
                pictureBox1.Image = Resources.tiger;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                context.SelectedImage = Resources.mountain;
                pictureBox1.Image = Resources.mountain;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                context.SelectedImage = Resources.butterfly;
                pictureBox1.Image = Resources.butterfly;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            context.RichText = richTextBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isValid(textBox2.Text) || !isValid(textBox3.Text))
            {
                MessageBox.Show("Введите правильный Email!");
            }
            else if (textBox1.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Введите правильно имя!");
            }
            else if(richTextBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Введите пожелание!");
            }
            else
            {
                Navigation.Open(new CardForm(context));
            }
            
            
        }

        public static bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);

            if (isMatch.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation.Open(new AllCards());
        }
    }
}
