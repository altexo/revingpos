using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class Payments
    {
        public Payments()
        {
            SaleDetails = new HashSet<SaleDetails>();
        }

        public int Id { get; set; }
        public string Method { get; set; }

        public virtual ICollection<SaleDetails> SaleDetails { get; set; }
    }
}
