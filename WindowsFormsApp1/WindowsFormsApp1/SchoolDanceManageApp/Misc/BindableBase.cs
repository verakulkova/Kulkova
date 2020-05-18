﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDanceManageApp.Misc
{
    //[System.ComponentModel.DesignerCategory("")]
    public class BindableBase : INotifyPropertyChanged
    {
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        //INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
    }
}