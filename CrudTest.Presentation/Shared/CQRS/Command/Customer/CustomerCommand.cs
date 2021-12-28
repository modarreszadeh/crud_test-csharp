using System;
using MediatR;

namespace Shared.CQRS.Command.Customer
{
    public class AddCustomerCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BankAccountNumber { get; set; }
    }

    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class UpdateCustomerCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BankAccountNumber { get; set; }
    }
}