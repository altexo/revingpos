using System;
using System.Collections.Generic;

namespace revingpos_api.Models
{
    public partial class Products
    {
        public Products()
        {
            Sales = new HashSet<Sales>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public string SupplierCode { get; set; }
        public string Description { get; set; }
        public int IsDeleted { get; set; }
        public long SuppliersId { get; set; }
        public int ProductStatesId { get; set; }
        public long CategoriesId { get; set; }
        public long BrandsId { get; set; }
        public long TagsId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long InventoryId { get; set; }

        public virtual Brands Brands { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ProductStates ProductStates { get; set; }
        public virtual Suppliers Suppliers { get; set; }
        public virtual Tags Tags { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
