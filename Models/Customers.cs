using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class Customers
    {
        public Customers()
        {
            SaleDetails = new HashSet<SaleDetails>();
        }

        public long Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<SaleDetails> SaleDetails { get; set; }
    }
}
