using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace revingpos_api.Models
{
    public partial class RevingposContext : DbContext
    {
        public RevingposContext()
        {
        }

        public RevingposContext(DbContextOptions<RevingposContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryStates> InventoryStates { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<ProductStates> ProductStates { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SaleDetails> SaleDetails { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=revingpos;user=root;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>(entity =>
            {
                entity.ToTable("brands");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BrandName)
                    .HasColumnName("brand_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("category_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customer_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.LocationsId, e.InventoryStatesId })
                    .HasName("PRIMARY");

                entity.ToTable("inventory");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.InventoryStatesId)
                    .HasName("fk_inventory_inventory_states1_idx");

                entity.HasIndex(e => e.LocationsId)
                    .HasName("fk_inventory_locations1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LocationsId)
                    .HasColumnName("locations_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.InventoryStatesId)
                    .HasColumnName("inventory_states_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InOrder)
                    .HasColumnName("in_order")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.InStock)
                    .HasColumnName("in_stock")
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(d => d.InventoryStates)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.InventoryStatesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_inventory_states1");

                entity.HasOne(d => d.Locations)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_locations1");
            });

            modelBuilder.Entity<InventoryStates>(entity =>
            {
                entity.ToTable("inventory_states");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InventoryState)
                    .HasColumnName("inventory_state")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("locations");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Colony)
                    .HasColumnName("colony")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ExtNumber)
                    .HasColumnName("ext_number")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.IntNumber)
                    .HasColumnName("int_number")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.LocationName)
                    .HasColumnName("location_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasColumnType("varchar(191)");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("payment_status");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentStatusName)
                    .HasColumnName("payment_status_name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.ToTable("payments");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Method)
                    .HasColumnName("method")
                    .HasColumnType("varchar(191)");
            });

            modelBuilder.Entity<ProductStates>(entity =>
            {
                entity.ToTable("product_states");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductState)
                    .HasColumnName("product_state")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                // entity.HasKey(e => new { e.Id, e.SuppliersId, e.ProductStatesId, e.CategoriesId, e.BrandsId, e.TagsId, e.InventoryId })
                //     .HasName("PRIMARY");
                entity.HasKey(e => new { e.Id })
                    .HasName("PRIMARY");

                entity.ToTable("products");

                entity.HasIndex(e => e.BrandsId)
                    .HasName("fk_products_brands1_idx");

                entity.HasIndex(e => e.CategoriesId)
                    .HasName("fk_products_categories1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.InventoryId)
                    .HasName("fk_products_inventory1_idx");

                entity.HasIndex(e => e.ProductStatesId)
                    .HasName("fk_products_product_states1_idx");

                entity.HasIndex(e => e.SuppliersId)
                    .HasName("fk_products_suppliers1_idx");

                entity.HasIndex(e => e.TagsId)
                    .HasName("fk_products_tags1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SuppliersId)
                    .HasColumnName("suppliers_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductStatesId)
                    .HasColumnName("product_states_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriesId)
                    .HasColumnName("categories_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BrandsId)
                    .HasColumnName("brands_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.TagsId)
                    .HasColumnName("tags_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("supplier_code")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.Brands)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_products_brands1");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_products_categories1");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Products)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_products_inventory1");

                entity.HasOne(d => d.ProductStates)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductStatesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_products_product_states1");

                entity.HasOne(d => d.Suppliers)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SuppliersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_products_suppliers1");

                entity.HasOne(d => d.Tags)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TagsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_products_tags1");
            });

            modelBuilder.Entity<SaleDetails>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PaymentsId, e.PaymentStatusId, e.CustomersId, e.UsersId })
                    .HasName("PRIMARY");

                entity.ToTable("sale_details");

                entity.HasIndex(e => e.CustomersId)
                    .HasName("fk_sale_details_customers1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PaymentStatusId)
                    .HasName("fk_sales_payment_status1_idx");

                entity.HasIndex(e => e.PaymentsId)
                    .HasName("fk_sales_payments1_idx");

                entity.HasIndex(e => e.UsersId)
                    .HasName("fk_sale_details_users1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PaymentsId)
                    .HasColumnName("payments_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentStatusId)
                    .HasColumnName("payment_status_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomersId)
                    .HasColumnName("customers_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UsersId)
                    .HasColumnName("users_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.Customers)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.CustomersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sale_details_customers1");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sales_payment_status1");

                entity.HasOne(d => d.Payments)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.PaymentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sales_payments1");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.SaleDetails)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sale_details_users1");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SaleDetailsId, e.ProductsId })
                    .HasName("PRIMARY");

                entity.ToTable("sales");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ProductsId)
                    .HasName("fk_sales_products1_idx");

                entity.HasIndex(e => e.SaleDetailsId)
                    .HasName("fk_sales_sale_details1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SaleDetailsId)
                    .HasColumnName("sale_details_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductsId)
                    .HasColumnName("products_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("double(5,2)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.Sales)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sales_products1");

                entity.HasOne(d => d.SaleDetails)
                    .WithMany(p => p.Sales)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.SaleDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sales_sale_details1");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.SupplierName)
                    .HasColumnName("supplier_name")
                    .HasColumnType("varchar(191)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.ToTable("tags");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.TagName)
                    .HasColumnName("tag_name")
                    .HasColumnType("varchar(191)");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.ToTable("user_roles");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserRolesId })
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserRolesId)
                    .HasName("fk_users_user_roles1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserRolesId)
                    .HasColumnName("user_roles_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasColumnType("varchar(191)");

                entity.HasOne(d => d.UserRoles)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRolesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_user_roles1");
            });
        }
    }
}
