using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class Locations
    {
        public Locations()
        {
            Inventory = new HashSet<Inventory>();
        }

        public long Id { get; set; }
        public string LocationName { get; set; }
        public string Street { get; set; }
        public string IntNumber { get; set; }
        public string ExtNumber { get; set; }
        public string Colony { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
