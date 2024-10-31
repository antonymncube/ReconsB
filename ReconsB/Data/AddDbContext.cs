using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReconsB.model;

namespace ReconsB.Data
{
    public class AddDbContext : IdentityDbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {
        }

        public DbSet<ErpInvoice> ErpInvoice { get; set; }
        public DbSet<Model.Team> Teams { get; set; }
        public DbSet<Invoice> invoice { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Statement> statement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specify precision and scale for decimal properties
            modelBuilder.Entity<ErpInvoice>()
                .Property(e => e.InvoiceAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ErpInvoice>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ErpInvoice>()
                .Property(e => e.TotalTax)
                .HasPrecision(18, 2);

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
        }
    }
}
