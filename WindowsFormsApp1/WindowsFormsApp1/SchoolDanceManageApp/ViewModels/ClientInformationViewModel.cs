using SchoolDanceManageApp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

                query.numbers_lessons_ab = int.Parse(value);
                Globals.Db.SaveChanges();
            }
        }

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

                query.number_visits = int.Parse(value);
                Globals.Db.SaveChanges();
            }
        }

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

                query.num_gr = int.Parse(value);
                Globals.Db.SaveChanges();
            }
        }

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

                query.visits_ind = value;
                Globals.Db.SaveChanges();
            }
        }

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

                query.visits_gr = value;
                Globals.Db.SaveChanges();
            }
        }

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
    }
}
