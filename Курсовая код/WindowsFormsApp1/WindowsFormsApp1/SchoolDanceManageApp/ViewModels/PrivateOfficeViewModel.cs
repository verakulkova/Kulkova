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
                Navigation.OpenDialog(new BookAbonementView());
            });

            OpenSignUpForClassCommand = new RelayCommand((arg) =>
            {
                Navigation.OpenDialog(new SignUpForClassView((ClassType)arg));
            });

            OpenClientInfoCommand = new RelayCommand((arg) =>
            {
                Navigation.OpenDialog(new ClientInformationView(new Tuple<int, bool>(ClientId, (bool)arg)));
            });
        }
    }
}
