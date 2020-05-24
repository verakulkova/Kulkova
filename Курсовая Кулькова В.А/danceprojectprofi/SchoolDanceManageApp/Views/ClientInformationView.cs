using SchoolDanceManageApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDanceManageApp.Views
{
    public partial class ClientInformationView : Form
    {
        ClientInformationViewModel context;
        public ClientInformationView(Tuple<int, bool> argData)
        {
            context = new ClientInformationViewModel();
            context.ClientId = argData.Item1;
            context.IsReadonly = argData.Item2;
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();

            button4.DataBindings.Add(new Binding(nameof(button4.Enabled), context, nameof(context.AreComboBoxesEnabled), false, DataSourceUpdateMode.Never));
            button4.DataBindings.Add(new Binding(nameof(button4.Visible), context, nameof(context.AreComboBoxesEnabled), false, DataSourceUpdateMode.Never));

            if (context.ClientHadGroupTest)
            {
                comboBox2.DataSource = context.Variants.Clone();
                comboBox2.DataBindings.Add(new Binding(nameof(comboBox2.SelectedIndex), context, nameof(context.TestGroupIndex), false, DataSourceUpdateMode.OnPropertyChanged));
                comboBox2.DataBindings.Add(new Binding(nameof(comboBox2.Enabled), context, nameof(context.AreComboBoxesEnabled), false, DataSourceUpdateMode.Never));
            }
            else
            {
                comboBox2.Enabled = false;
            }

            if (context.ClientHadIndividualTest)
            {
                comboBox1.DataSource = context.Variants.Clone();
                comboBox1.DataBindings.Add(new Binding(nameof(comboBox1.Enabled), context, nameof(context.AreComboBoxesEnabled), false, DataSourceUpdateMode.Never));
                comboBox1.DataBindings.Add(new Binding(nameof(comboBox1.SelectedIndex), context, nameof(context.TestIndividualIndex), false, DataSourceUpdateMode.OnPropertyChanged));
            }
            else
            {
                comboBox1.Enabled = false;
            }
            
            if(context.ClientHadGroupOne)
            {
                textBox2.DataBindings.Add(new Binding(nameof(textBox2.ReadOnly), context, nameof(context.IsReadonly), false, DataSourceUpdateMode.Never));
                textBox2.DataBindings.Add(new Binding(nameof(textBox2.Text), context, nameof(context.GroupCount), false, DataSourceUpdateMode.OnPropertyChanged));
            }
            else
            {
                textBox2.Enabled = false;
            }

            if(context.ClientHadIndividualOne)
            {
                textBox3.DataBindings.Add(new Binding(nameof(textBox3.ReadOnly), context, nameof(context.IsReadonly), false, DataSourceUpdateMode.Never));
                textBox3.DataBindings.Add(new Binding(nameof(textBox3.Text), context, nameof(context.IndividualCount), false, DataSourceUpdateMode.OnPropertyChanged));
            }
            else
            {
                textBox3.Enabled = false;
            }

            CheckForAbonement();

            context.PropertyChanged += Context_PropertyChanged;
        }

        private void CheckForAbonement()
        {
            if (context.ClientHadAbonement)
            {
                textBox1.DataBindings.Add(new Binding(nameof(textBox1.ReadOnly), context, nameof(context.IsReadonly), false, DataSourceUpdateMode.Never));
                textBox1.DataBindings.Add(new Binding(nameof(textBox1.Text), context, nameof(context.AbonementCount), false, DataSourceUpdateMode.OnPropertyChanged));
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void Context_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(context.ClientHadAbonement))
            {
                CheckForAbonement();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            context.OpenClientInformationCommand.Execute(null);
        }
    }
}
