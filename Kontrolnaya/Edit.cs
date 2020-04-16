using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontrolnaya
{
    public partial class Edit : Form
    {
        public contEntities db = new contEntities();
        s_students item;
        public Edit()
        {
            InitializeComponent();
        }
    }
}
