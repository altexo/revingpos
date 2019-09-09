using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class Sales
    {
        public long Id { get; set; }
        public double? Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long SaleDetailsId { get; set; }
        public long ProductsId { get; set; }

        public virtual Products Products { get; set; }
        public virtual SaleDetails SaleDetails { get; set; }
    }
}
