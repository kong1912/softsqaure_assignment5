using Microsoft.EntityFrameworkCore;
using Project1.Model;

namespace Project1.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        
    
    }
}
