using Microsoft.EntityFrameworkCore;


namespace CrudTest.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhsot;Port=5432;Database=CrudTaskDb;Username=postgres;Password=Mohammad1250633672");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}
