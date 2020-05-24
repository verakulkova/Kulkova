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
    class AdminPanelViewModel : BindableBase
    {
        // Данные из базы для таблицы во View
        public object DataSource
        {
            get
            {
                var clientinfo = Globals.Db.clientinformation.ToList();

                var query = (from info in clientinfo
                             join a in Globals.Db.abonements on info.id_client equals a.id_client
                             join b in Globals.Db.individ_one_trainig on info.id_individ equals b.id_individ
                             join c in Globals.Db.probnoe_individ on info.id_prob_ind equals c.id_prob_ind
                             join pr in Globals.Db.probnoe_group on info.id_client equals pr.id_client
                             join raz in Globals.Db.grouponetraining_client on info.id_client equals raz.id_client
                             join d in Globals.Db.dancedirection on raz.id_client equals d.id_dance
                             orderby info.id_client
                             select new
                             {
                                 info.surname,
                                 info.name,
                                 info.lastname,
                                 a.kind_ab,
                                 a.kind_numbers_in_ab,
                                 a.numbers_lessons_ab,
                                 b.number_visits,
                                 raz.num_gr,
                                 c.visits_ind,
                                 pr.visits_gr,
                                 d.name_dance,
                                 info.id_client
                             }).Distinct().ToList();

                return query;
            }
        }
        // Команда открытия формы ClientInformation
        public ICommand OpenClientInformationCommand { get; set; }

        public AdminPanelViewModel()
        {
            OpenClientInformationCommand = new RelayCommand((arg) =>
            {
                Navigation.OpenDialog(new ClientInformationView((Tuple<int, bool>)arg));
            });
        }
    }
}
