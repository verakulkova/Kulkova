//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolDanceManageApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class grouponetraining_client
    {
        public int id_client { get; set; }
        public int id_dance { get; set; }
        public Nullable<int> num_gr { get; set; }
    
        public virtual clientinformation clientinformation { get; set; }
        public virtual dancedirection dancedirection { get; set; }
    }
}