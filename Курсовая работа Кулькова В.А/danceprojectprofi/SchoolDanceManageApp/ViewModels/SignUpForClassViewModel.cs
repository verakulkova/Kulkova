using SchoolDanceManageApp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolDanceManageApp.ViewModels
{
    public enum ClassType
    {
        Single,
        Test
    }

    class SignUpForClassViewModel : BindableBase
    {
        private int id_client;
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

        public int ClassActionTypeIndex { get; set; }

        public string SelectedDirection { get; set; }

        public ICommand SignUpForTestCommand { get; private set; }

        public ICommand SignUpForOneCommand { get; private set; }

        public SignUpForClassViewModel()
        {
            //Команда запроса тестовых занятий
            SignUpForTestCommand = new RelayCommand((arg) =>
            {
                switch(ClassActionTypeIndex)
                {
                    case 0:
                        Globals.Db.probnoe_group.Add(new probnoe_group()
                        {
                            id_client = ClientId,
                            id_dance = Globals.Db.dancedirection.Single(x => x.name_dance == SelectedDirection)?.id_dance,
                            visits_gr = "Да"
                        });
                        Globals.Db.SaveChanges();
                        break;
                    case 1:
                        var individ = Globals.Db.probnoe_individ.Add(new probnoe_individ()
                        {
                            visits_ind = "Да"
                        });
                        Globals.Db.SaveChanges();
                        Globals.Db.clientinformation.Single(x => x.id_client == ClientId).id_prob_ind = individ.id_prob_ind;
                        Globals.Db.SaveChanges();
                        break;
                }
            });

            SignUpForOneCommand = new RelayCommand((arg) =>
            {
                switch (ClassActionTypeIndex)
                {
                    case 0:
                        var query = Globals.Db.clientinformation
                            .Where(x => x.id_client == ClientId)
                            .Join(Globals.Db.grouponetraining_client, x => x.id_client, y => y.id_client, (client, grouponetraining_client) => grouponetraining_client);

                        if(query.Count() != 0)
                        {
                            query.First().num_gr++;
                            
                        }
                        else
                        {
                            Globals.Db.grouponetraining_client.Add(new grouponetraining_client()
                            {
                                id_client = ClientId,
                                id_dance = Globals.Db.dancedirection.Single(x => x.name_dance == SelectedDirection).id_dance,
                                num_gr = 1
                            });
                        }

                        Globals.Db.SaveChanges();
                        break;
                    case 1:
                        var query2 = Globals.Db.clientinformation
                            .Where(x => x.id_client == ClientId)
                            .Join(Globals.Db.individ_one_trainig, x => x.id_individ, y => y.id_individ, (client, individ_one_trainig) => individ_one_trainig);

                        if(query2.Count() != 0)
                        {
                            var tmp = query2.First();
                            tmp.number_visits = tmp.number_visits == null ? 1 : tmp.number_visits+1;
                            Globals.Db.SaveChanges();
                        }
                        else
                        {
                            var tmpIndivid = Globals.Db.individ_one_trainig.Add(new individ_one_trainig()
                            {
                                number_visits = 1
                            });
                            Globals.Db.SaveChanges();
                            Globals.Db.clientinformation.Single(x => x.id_client == ClientId).id_individ = tmpIndivid.id_individ;
                            Globals.Db.SaveChanges();
                        }
                        break;
                }
            });
        }
    }
}
