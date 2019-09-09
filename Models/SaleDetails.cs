using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class SaleDetails
    {
        public SaleDetails()
        {
            Sales = new HashSet<Sales>();
        }

        public long Id { get; set; }
        public int PaymentsId { get; set; }
        public int PaymentStatusId { get; set; }
        public long CustomersId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UsersId { get; set; }

        public virtual Customers Customers { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public virtual Payments Payments { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
