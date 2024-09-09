using MasterTables.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterTables.Infrastructure.Data
{
    public class MasterTablesDbContext : DbContext
    {
        public MasterTablesDbContext(DbContextOptions<MasterTablesDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
        }
    }

}
