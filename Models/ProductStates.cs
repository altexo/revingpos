using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class ProductStates
    {
        public ProductStates()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string ProductState { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
