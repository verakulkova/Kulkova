using SchoolDanceManageApp.Misc;
using SchoolDanceManageApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SchoolDanceManageApp.ViewModels
{
    public enum AuthType
    {
        SignUp,
        SignIn
    }

    class AuthorizationViewModel : BindableBase
    {
        private AuthType authType;
        private string login;
        private string password;

        public AuthType AuthType
        {
            get
            {
                return authType;
            }
            set
            {
                authType = value;
                OnPropertyChanged(nameof(AuthType));
                OnPropertyChanged(nameof(Label));
            }
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Label
        {
            get
            {
                switch(AuthType)
                {
                    case AuthType.SignIn:
                        return "Введите данные для авторизации.";
                    case AuthType.SignUp:
                        return "Введите данные для регистрации.";
                    default:
                        throw new Exception("Что-то пошло не так.");
                }
            }
        }

        public Action RequestClose { get; set; }

        public ICommand LoginCommand { get; set; }

        public AuthorizationViewModel()
        {
            LoginCommand = new RelayCommand((arg) =>
            {
                switch (AuthType)
                {
                    case AuthType.SignIn:
                        var clientRoles = Globals.Db.clientinformation
                        .Where(x => x.login == login && x.password == password)
                        .Join(Globals.Db.roles, x => x.id_role, y => y.id_role, (client, role) => new { Id = client.id_client, Role = role.role })
                        .ToList();

                        //TODO Немного отступаем от MVVM для упрощения
                        if (clientRoles.Count > 1)
                        {
                            MessageBox.Show("Несколько пользователей с таким логином и паролем. Обратитесь к администратору!");
                            return;
                        }
                        else if(clientRoles.Count == 0)
                        {
                            MessageBox.Show("Неверный логин или пароль!");
                            return;
                        }

                        bool isAdmin = clientRoles[0].Role == "admin";
                        Navigation.Open(isAdmin ? new AdminPanelView() : (Form)new PrivateOfficeView(clientRoles[0].Id));
                        break;
                    case AuthType.SignUp:
                        var newRole = Globals.Db.roles.Add(new roles()
                        {
                            role = "client"
                        });
                        Globals.Db.SaveChanges();

                        var newClient = Globals.Db.clientinformation.Add(new clientinformation()
                        {
                            login = login,
                            password = password,
                            id_role = newRole.id_role
                        });

                        Globals.Db.SaveChanges();
                        Navigation.Open(new PrivateOfficeView(newClient.id_client));
                        break;
                    default:
                        throw new Exception("Что-то пошло не так.");
                }

                RequestClose?.Invoke();
            });
        }
    }
}
