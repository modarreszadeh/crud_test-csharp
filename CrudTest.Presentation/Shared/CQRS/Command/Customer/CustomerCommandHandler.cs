using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrudTest.Domain.Models;
using MediatR;

namespace Shared.CQRS.Command.Customer
{
    public class CustomerCommandHandler : IRequestHandler<AddCustomerCommand>
    {
        private readonly AppDbContext _context;

        public CustomerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new CrudTest.Domain.Models.Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                BankAccountNumber = request.BankAccountNumber,
                DateOfBirth = request.DateOfBirth,
            };
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }


}