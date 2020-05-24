using SchoolDanceManageApp.Misc;
using SchoolDanceManageApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolDanceManageApp.ViewModels
{
    class PrivateOfficeViewModel : BindableBase
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

        // У клиента были пробные занятия

        public bool ClientHadNotTest
        {
            get
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.probnoe_group, x => x.id_client, y => y.id_client, (client, probnoe_group) => probnoe_group);

                var query2 = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.probnoe_individ, x => x.id_prob_ind, y => y.id_prob_ind, (client, probnoe_individ) => probnoe_individ);

                return !((query.Count() != 0 && query.First().visits_gr == "Да") || (query2.Count() != 0 && query2.First().visits_ind == "Да"));
            }
        }

        public ICommand OpenTimetableCommand { get; private set; }

        public ICommand OpenDirectionsCommand { get; private set; }

        public ICommand OpenBookingCommand { get; private set; }

        public ICommand OpenSignUpForClassCommand { get; private set; }

        public ICommand OpenClientInfoCommand { get; private set; }

        public PrivateOfficeViewModel()
        {
            OpenTimetableCommand = new RelayCommand((arg) =>
            {
                Navigation.OpenDialog(new TimetableView());
            });

            OpenDirectionsCommand = new RelayCommand((arg) =>
            {
                Navigation.OpenDialog(new DirectionsView());
            });

            OpenBookingCommand = new RelayCommand((arg) =>
            {
                Navigation.OpenDialog(new BookAbonementView(ClientId));
            });

            OpenSignUpForClassCommand = new RelayCommand((arg) =>
            {
                Navigation.OpenDialog(new SignUpForClassView((ClassType)arg, ClientId));
                OnPropertyChanged(nameof(ClientHadNotTest));
            });

            OpenClientInfoCommand = new RelayCommand((arg) =>
            {
                Navigation.OpenDialog(new ClientInformationView(new Tuple<int, bool>(ClientId, (bool)arg)));
            });
        }
    }
}
