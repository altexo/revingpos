using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Products = new HashSet<Products>();
        }

        public long Id { get; set; }
        public decimal? InStock { get; set; }
        public decimal? InOrder { get; set; }
        public long LocationsId { get; set; }
        public int InventoryStatesId { get; set; }

        public virtual InventoryStates InventoryStates { get; set; }
        public virtual Locations Locations { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
