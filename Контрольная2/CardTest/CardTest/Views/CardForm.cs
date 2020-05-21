using CardTest.Misc;
using CardTest.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardTest.Views
{
    public partial class CardForm : Form
    {
        MainFormViewModel model;
        public CardForm(MainFormViewModel model, bool buttonsActive = true)
        {
            this.model = model;
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = model.SelectedImage;
            label1.Text = model.Name;
            richTextBox1.Text = model.RichText;

            string AdditionalText = $"\n{model.NameSender}" + $"\n{model.EmailSender}";
            richTextBox1.AppendText(AdditionalText);
            richTextBox1.Select(richTextBox1.Text.IndexOf(AdditionalText) + 1, AdditionalText.Length);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;

            label2.Text = string.Format(label2.Text, model.Email);
            label2.Enabled = label2.Visible = !buttonsActive;

            button1.Enabled = button1.Visible = buttonsActive;
            button2.Enabled = button2.Visible = buttonsActive;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Navigation.Open(new CardForm(model, false));

                Globals.Db.Cards.Add(new Cards()
                {
                    id = Globals.Db.Cards.Count() + 1,
                    name = model.Name,
                    nameSender = model.NameSender,
                    email = model.Email,
                    emailSender = model.EmailSender,
                    wish = model.RichText

                });

                Globals.Db.SaveChanges();
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка с подключением БД");
            }
        }
    }
}
