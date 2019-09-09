using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class Tags
    {
        public Tags()
        {
            Products = new HashSet<Products>();
        }

        public long Id { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
