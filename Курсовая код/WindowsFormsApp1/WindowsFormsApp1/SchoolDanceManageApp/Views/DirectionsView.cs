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
    public partial class DirectionsView : Form
    {
        DirectionsViewModel context;
        public DirectionsView()
        {
            context = new DirectionsViewModel();
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            dataGridView1.ReadOnly = true;

            dataGridView1.DataBindingComplete += (sender, e) =>
            {
                dataGridView1.Columns[0].HeaderText = "Направление";
                dataGridView1.Columns[1].HeaderText = "Стиль";
            };

            dataGridView1.DataBindings.Add(new Binding(nameof(dataGridView1.DataSource), context, nameof(context.DataSource), false, DataSourceUpdateMode.Never));
        }
    }
}
