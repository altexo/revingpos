using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class Brands
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }

        public long Id { get; set; }
        public string BrandName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
