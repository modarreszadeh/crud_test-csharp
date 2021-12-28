using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudTest.Domain.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Shared.CQRS.Command.Customer.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator(AppDbContext _context)
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required")
            .NotNull()
            .WithMessage("Id is not null")
            .MustAsync(async (id, cancellationToken) =>
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
                return customer != null;
            }).WithMessage("Customer not found");

            RuleFor(x => x.FirstName).NotEmpty()
                .WithMessage("First name is required")
                .MaximumLength(50)
                .WithMessage("First name cannot be longer than 50 characters")
                .MinimumLength(2)
                .WithMessage("First name must be at least 2 characters");

            RuleFor(x => x.LastName).NotEmpty()
                .WithMessage("Last name is required")
                .MaximumLength(50)
                .WithMessage("Last name cannot be longer than 50 characters")
                .MinimumLength(2)
                .WithMessage("Last name must be at least 2 characters");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is not valid");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required")
                .CustomAsync((x, context, cancellationToken) =>
                {
                    /*
                        Validate that the phone number with libphonenumber-csharp package validators
                    */
                    try
                    {
                        var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                        var phoneNumber = phoneNumberUtil.Parse(x, null);
                        var isValid = phoneNumberUtil.IsValidNumber(phoneNumber);
                        if (!isValid)
                        {
                            context.AddFailure($"Phone number is not valid in Country :{phoneNumber.CountryCode}");
                        }
                    }
                    catch (System.Exception)
                    {
                        context.AddFailure("Phone number is not valid");
                    }

                    return System.Threading.Tasks.Task.CompletedTask;
                });

            RuleFor(x => x.BankAccountNumber)
                .NotEmpty()
                .WithMessage("Bank account number is required")
                .Matches(@"^\d{16}$")
                .WithMessage("Bank account number must be 16 digits");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required")
                .Must(x => x.Year > 1900)
                .WithMessage("Date of birth must be after 1900")
                .Must(x => x.Year < DateTime.Now.Year)
                .WithMessage("Date of birth must be before current year")
                .Must(x => x.Month > 0)
                .WithMessage("Month must be greater than 0")
                .Must(x => x.Month < 13)
                .WithMessage("Month must be less than 13")
                .Must(x => x.Day > 0)
                .WithMessage("Day must be greater than 0")
                .Must(x => x.Day < 32)
                .WithMessage("Day must be less than 32");
        }
    }
}