using SchoolDanceManageApp.Misc;
using SchoolDanceManageApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolDanceManageApp.ViewModels
{
    class MainMenuViewModel : BindableBase
    {
        public Action RequestClose { get; set; }

        public ICommand OpenAuthCommand { get; private set; }

        public ICommand OpenTimetableCommand { get; private set; }

        public ICommand OpenDirectionsCommand { get; private set; }

        public MainMenuViewModel()
        {
            OpenAuthCommand = new RelayCommand((arg) =>
            {
                Navigation.Open(new AuthorizationView((AuthType)arg));
                RequestClose?.Invoke();
            });

            OpenTimetableCommand = new RelayCommand((arg) =>
            {
                Navigation.Open(new TimetableView());
                RequestClose?.Invoke();
            });

            OpenDirectionsCommand = new RelayCommand((arg) =>
            {
                Navigation.Open(new DirectionsView());
                RequestClose?.Invoke();
            });
        }
    }
}
