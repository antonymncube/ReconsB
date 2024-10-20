

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReconsB.model.DTOs;
using ReconsB.Models;

namespace ReconsB.Data
{
    public class AddDbContext : IdentityDbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {
        }

        public DbSet<ErpInvoice> ErpInvoice { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Invoice> invoice { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Statement> statement { get; set; }


        

    }
}
