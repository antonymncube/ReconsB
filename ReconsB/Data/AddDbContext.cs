using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReconsB.model;
using ReconsB.Model;

namespace ReconsB.Data
{
    public class AddDbContext : IdentityDbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Invoice>()
                .Property(i => i.InvoiceAmount)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Invoice>()
                .Property(i => i.TotalAmount)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Invoice>()
                .Property(i => i.TotalTax)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Statement>()
                .Property(s => s.Days90)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Statement>()
                .Property(s => s.OpeningBalance)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Statement>()
                .Property(s => s.TotalBalance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PurchaseOrder>()
               .HasMany(po => po.Items) // One PurchaseOrder has many PurchaseOrderItems
               .WithOne(item => item.PurchaseOrder) // Each PurchaseOrderItem has one PurchaseOrder
               .HasForeignKey(item => item.PurchaseOrderId);
        }
    }
}
