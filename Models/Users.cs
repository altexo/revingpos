using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class Users
    {
        public Users()
        {
            SaleDetails = new HashSet<SaleDetails>();
        }

        public int Id { get; set; }
        public int UserRolesId { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual UserRoles UserRoles { get; set; }
        public virtual ICollection<SaleDetails> SaleDetails { get; set; }
    }
}
