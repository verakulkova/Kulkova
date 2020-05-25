using SchoolDanceManageApp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDanceManageApp.ViewModels
{
    class DirectionsViewModel : BindableBase //Направление
    {
        // Данные для таблицы с направленями
        public object DataSource
        {
            get
            {
                var dancedir = (from dance in Globals.Db.dancedirection select dance).ToList();
                var query = (from dance in dancedir select new { dance.name_dance, dance.style }).ToList();

                return query;
            }
        }
    }
}
