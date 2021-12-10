﻿using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    BankAccountNumber = "12345",
                    DateOfBirth = new DateTime(1980,1,1),
                    Email = "Jhon@Doe.com",
                    PhoneNumber = "+12345678"
                },
                new Customer
                {
                    FirstName = "Ali",
                    LastName = "Akbari",
                    BankAccountNumber = "54321",
                    DateOfBirth = new DateTime(2000,1,1),
                    Email = "Ali@Akbari.com",
                    PhoneNumber = "+87654321"
                },
            };
        }
    }
}