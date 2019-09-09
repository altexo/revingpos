using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class InventoryStates
    {
        public InventoryStates()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string InventoryState { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
