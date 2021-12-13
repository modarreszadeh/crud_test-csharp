using Microsoft.EntityFrameworkCore;


namespace CrudTest.Domain.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql("Host=localhsot;Database=CrudTaskDb;Username=postgres;Password=Mohammad1250633672");
        //     base.OnConfiguring(optionsBuilder);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Customer>()
               .Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar");

            modelBuilder.Entity<Customer>()
                .Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar");

            modelBuilder.Entity<Customer>()
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnType("varchar");

            modelBuilder.Entity<Customer>()
                .Property(x => x.BankAccountNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar");

            modelBuilder.Entity<Customer>()
                .Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            base.OnModelCreating(modelBuilder);
        }
    }

}
