using Microsoft.EntityFrameworkCore;


namespace CrudTest.Domain.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Customer>()
               .Property(x => x.LastName)
               .IsRequired()
               .HasColumnType("varchar(50)");

            modelBuilder.Entity<Customer>()
                .Property(x => x.PhoneNumber)
                .IsRequired()
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<Customer>()
                .Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Customer>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .Property(x => x.BankAccountNumber)
                .IsRequired()
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<Customer>()
                .Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            base.OnModelCreating(modelBuilder);
        }
    }

}
