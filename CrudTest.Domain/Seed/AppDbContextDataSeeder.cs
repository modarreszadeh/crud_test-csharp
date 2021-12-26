using CrudTest.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTest.Domain.Seed
{
    public class AppDbContextDataSeeder
    {
        public static async Task SeedAsync(AppDbContext context, ILogger<AppDbContextDataSeeder> logger)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(GeInitialCustomer());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(AppDbContext).Name);
            }
        }

        private static IEnumerable<Customer> GeInitialCustomer()
        {
            return new List<Customer>
            {
                new Customer
                {
                    FirstName = "Jhon",
                    LastName = "Doe",
                    BankAccountNumber = "123456789",
                    DateOfBirth = new DateTime(1980,1,1),
                    Email = "Jhon@Doe.com",
                    PhoneNumber = "+14844458571"
                },
                new Customer
                {
                    FirstName = "Mohammad",
                    LastName = "Modarreszadeh",
                    BankAccountNumber = "543214587",
                    DateOfBirth = new DateTime(2000,1,1),
                    Email = "modarreszadehmohammad@gmail.com",
                    PhoneNumber = "+989393639116"
                },
            };
        }
    }
}
