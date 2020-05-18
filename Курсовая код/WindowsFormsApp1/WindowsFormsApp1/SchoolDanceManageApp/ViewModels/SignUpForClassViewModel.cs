using SchoolDanceManageApp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDanceManageApp.ViewModels
{
    public enum ClassType
    {
        Single,
        Test
    }

    class SignUpForClassViewModel : BindableBase
    {
        private ClassType classType;

        public ClassType ClassType
        {
            get
            {
                return classType;
            }
            set
            {
                classType = value;
                OnPropertyChanged(nameof(ClassType));
            }
        }
    }
}
