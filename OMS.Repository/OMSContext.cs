using OMS.Core.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OMS.Repository
{
    public class OMSContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public OMSContext() : base("OMSDB") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<CategoryVariant> CategoryVariants { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<VariantOption> VariantOptions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
