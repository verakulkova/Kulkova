using SchoolDanceManageApp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDanceManageApp.ViewModels
{
    class TimetableViewModel : BindableBase
    {
        private string surnameFilter = string.Empty;
        private string firstNameFilter = string.Empty;
        private string directionFilter = string.Empty;
        private DateTime dateFilter = DateTime.Now;
        private bool dateFilterEnabled = false;

        public bool DateFilterEnabled
        {
            get
            {
                return dateFilterEnabled;
            }
            set
            {
                dateFilterEnabled = value;
                OnPropertyChanged(nameof(DateFilterEnabled));
                OnPropertyChanged(nameof(DataSource));
            }
        }
        public string SurnameFilter
        {
            get
            {
                return surnameFilter;
            }
            set
            {
                surnameFilter = value;
                OnPropertyChanged(nameof(SurnameFilter));
                OnPropertyChanged(nameof(DataSource));
            }
        }

        public string FirstNameFilter
        {
            get
            {
                return firstNameFilter;
            }
            set
            {
                firstNameFilter = value;
                OnPropertyChanged(nameof(FirstNameFilter));
                OnPropertyChanged(nameof(DataSource));
            }
        }

        public string DirectionFilter
        {
            get
            {
                return directionFilter;
            }
            set
            {
                directionFilter = value;
                OnPropertyChanged(nameof(DirectionFilter));
                OnPropertyChanged(nameof(DataSource));
            }
        }

        public DateTime DateFilter
        {
            get
            {
                return dateFilter;
            }
            set
            {
                dateFilter = value;
                OnPropertyChanged(nameof(DateFilter));
                OnPropertyChanged(nameof(DataSource));
            }
        }

        public object DataSource
        {
            get
            {
                var timesheet = (from time in Globals.Db.timetable
                             select time).ToList();

                var query = (from time in timesheet
                             join d in Globals.Db.dancedirection on time.id_dance equals d.id_dance
                             join tt in Globals.Db.teachers on d.id_dance equals tt.id_teacher
                             orderby time.data
                             select new
                             {
                                 time.data,
                                 d.name_dance,
                                 tt.surname_teacher,
                                 tt.name_teacher,
                                 tt.lastname_teacher
                             })
                             .Where(x => 
                                 x.name_dance.Contains(directionFilter)
                                 && x.surname_teacher.Contains(surnameFilter)
                                 && x.name_teacher.Contains(firstNameFilter)
                                 && (dateFilterEnabled ? x.data.Date == dateFilter.Date : true))
                             .ToList();

                return query;
            }
        }
    }
}
