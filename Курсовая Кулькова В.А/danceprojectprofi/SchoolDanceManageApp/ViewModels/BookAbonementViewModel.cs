using SchoolDanceManageApp.Misc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolDanceManageApp.ViewModels
{
    class BookAbonementViewModel : BindableBase
    {
        private int id_client;

        public int ClientId
        {
            get
            {
                return id_client;
            }
            set
            {
                id_client = value;
                OnPropertyChanged(nameof(ClientId));
            }
        }

        public ICommand BookAbonementCommand { get; set; }

        // Групповое или индивидуальное занятие
        public int ClassActionTypeIndex { get; set; }


        // Выбранное количество занятий в абонементе
        public int SelectedCount { get; set; } = 0;


        public BookAbonementViewModel()
        {
            //Команда создающая пользователю абонемент
            BookAbonementCommand = new RelayCommand((arg) =>
            {
               
                Globals.Db.abonements.Add(new abonements()
                {
                    kind_ab = ClassActionTypeIndex == 0 ? "Групповые занятия" : "Индивидуальные занятия",
                    kind_numbers_in_ab = SelectedCount,
                    numbers_lessons_ab = 0,
                    id_client = id_client
                });

                Globals.Db.SaveChanges();
            });
        }
    }
}
