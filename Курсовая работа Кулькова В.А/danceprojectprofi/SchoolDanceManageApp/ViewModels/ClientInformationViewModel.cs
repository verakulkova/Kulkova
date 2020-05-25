using SchoolDanceManageApp.Misc;
using SchoolDanceManageApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolDanceManageApp.ViewModels
{
    class ClientInformationViewModel : BindableBase
    {
        private int id_client;
        private bool isReadonly;

        public string[] Variants = { "Да", "Нет" };

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

        // Может ли текущий пользователь редактировать информацию или нет
        public bool IsReadonly
        {
            get
            {
                return isReadonly;
            }
            set
            {
                isReadonly = value;
                OnPropertyChanged(nameof(IsReadonly));
                OnPropertyChanged(nameof(AreComboBoxesEnabled));
            }
        }
        public bool AreComboBoxesEnabled
        {
            get
            {
                return !IsReadonly;
            }
        }
        // Количество занятий по абнементу
        public string AbonementCount
        {
            get
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.abonements, x => x.id_client, y => y.id_client, (client, abonement) => abonement)
                    .First();

                return query.numbers_lessons_ab.ToString();
            }
            set
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.abonements, x => x.id_client, y => y.id_client, (client, abonement) => abonement)
                    .First();
                if (value.Trim()!= string.Empty && int.TryParse(value, out var tmpVal))
                query.numbers_lessons_ab = int.Parse(value);
                Globals.Db.SaveChanges();
            }
        }
        // Есть ли у клиента абонемен
        public bool ClientHadAbonement
        {
            get
            {
                return Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.abonements, x => x.id_client, y => y.id_client, (client, abonement) => abonement)
                    .Count() != 0;
            }
        }
        // Количество индивидуальных занятий
        public string IndividualCount
        {
            get
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.individ_one_trainig, x => x.id_individ, y => y.id_individ, (client, individ_one_trainig) => individ_one_trainig)
                    .First();

                return query.number_visits.ToString();
            }
            set
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.individ_one_trainig, x => x.id_individ, y => y.id_individ, (client, individ_one_trainig) => individ_one_trainig)
                    .First();
                if (value.Trim() != string.Empty && int.TryParse(value, out var tmpVal))
                    query.number_visits = int.Parse(value);
                Globals.Db.SaveChanges();
            }
        }
        // Количество групповых занятий
        public string GroupCount
        {
            get
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.grouponetraining_client, x => x.id_client, y => y.id_client, (client, grouponetraining_client) => grouponetraining_client)
                    .First();

                return query.num_gr.ToString();
            }
            set
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.grouponetraining_client, x => x.id_client, y => y.id_client, (client, grouponetraining_client) => grouponetraining_client)
                    .First();
                if (value.Trim() != string.Empty && int.TryParse(value, out var tmpVal))
                    query.num_gr = int.Parse(value);
                Globals.Db.SaveChanges();
            }
        }
        // наличие индивидуальных пробных занятий
        public string TestIndividual
        {
            get
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.probnoe_individ, x => x.id_prob_ind, y => y.id_prob_ind, (client, probnoe_individ) => probnoe_individ)
                    .First();

                return query.visits_ind.ToString();
            }
            set
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.probnoe_individ, x => x.id_prob_ind, y => y.id_prob_ind, (client, probnoe_individ) => probnoe_individ)
                    .First();
                if (value.Trim() != string.Empty && int.TryParse(value, out var tmpVal))
                    query.visits_ind = value;
                Globals.Db.SaveChanges();
            }
        }
        // Наличие пробных групповых занятий
        public string TestGroup
        {
            get
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.probnoe_group, x => x.id_client, y => y.id_client, (client, probnoe_group) => probnoe_group)
                    .First();

                return query.visits_gr.ToString();
            }
            set
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.probnoe_group, x => x.id_client, y => y.id_client, (client, probnoe_group) => probnoe_group)
                    .First();
                if (value.Trim() != string.Empty && int.TryParse(value, out var tmpVal))
                    query.visits_gr = value;
                Globals.Db.SaveChanges();
            }
        }
        // Связка занятий с combobox

        public int TestIndividualIndex
        {
            get
            {
                var tmpIndividual = TestIndividual;

                for (int i = 0; i < Variants.Length; i++)
                {
                    if (Variants[i] == tmpIndividual)
                    {
                        return i;
                    }
                }

                return -1;
            }
            set
            {
                if(value < 0)
                {
                    TestIndividual = null;
                }
                else
                {
                    TestIndividual = Variants[value];
                }
            }
        }
        // Связка занятий с combobox
        public int TestGroupIndex
        {
            get
            {
                var tmpGroup = TestGroup;

                for (int i = 0; i < Variants.Length; i++)
                {
                    if (Variants[i] == tmpGroup)
                    {
                        return i;
                    }
                }

                return -1;
            }
            set
            {
                if (value < 0)
                {
                    TestGroup = null;
                }
                else
                {
                    TestGroup = Variants[value];
                }
            }
        }
        // Запрашивал ли клиент групповые пробные занятия
        public bool ClientHadGroupTest
        {
            get
            {
                var query = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.probnoe_group, x => x.id_client, y => y.id_client, (client, probnoe_group) => probnoe_group);

                var result = (query.Count() != 0 && query.First().visits_gr == "Да");
                return result;
            }
        }
        /// Запрашивал ли клиент индивидуальные пробные занятия
        public bool ClientHadIndividualTest
        {
            get
            {
                var query2 = Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.probnoe_individ, x => x.id_prob_ind, y => y.id_prob_ind, (client, probnoe_individ) => probnoe_individ);

                var result = ((query2.Count() != 0 && query2.First().visits_ind == "Да"));
                return result;
            }
        }
        // Запрашивал ли клиент групповые разовые занятия
        public bool ClientHadGroupOne
        {
            get
            {
                return Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.grouponetraining_client, x => x.id_client, y => y.id_client, (client, grouponetraining_client) => grouponetraining_client)
                    .Count() != 0;
            }
        }
        // Запрашивал ли клиент индивидуальные разовые занятия
        public bool ClientHadIndividualOne
        {
            get
            {
                return Globals.Db.clientinformation
                    .Where(x => x.id_client == ClientId)
                    .Join(Globals.Db.individ_one_trainig, x => x.id_individ, y => y.id_individ, (client, individ_one_trainig) => individ_one_trainig)
                    .Count() != 0;
            }
        }



        public ICommand OpenClientInformationCommand { get; private set; }

        public ClientInformationViewModel()
        {
            OpenClientInformationCommand = new RelayCommand((arg) =>
            {
                Navigation.OpenDialog(new BookAbonementView(ClientId));
                OnPropertyChanged(nameof(ClientHadAbonement));
            });
        }
    }
}
