using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class PaymentStatus
    {
        public PaymentStatus()
        {
            SaleDetails = new HashSet<SaleDetails>();
        }

        public int Id { get; set; }
        public string PaymentStatusName { get; set; }

        public virtual ICollection<SaleDetails> SaleDetails { get; set; }
    }
}
