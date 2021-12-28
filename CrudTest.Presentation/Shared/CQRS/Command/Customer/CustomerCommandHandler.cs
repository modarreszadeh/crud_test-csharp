using System.Threading;
using System.Threading.Tasks;
using CrudTest.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Shared.CQRS.Command.Customer
{
    public class CustomerCommandHandler :
        IRequestHandler<AddCustomerCommand>,
        IRequestHandler<DeleteCustomerCommand>,
        IRequestHandler<UpdateCustomerCommand>
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

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == request.Id);
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Email = request.Email;
            customer.PhoneNumber = request.PhoneNumber;
            customer.BankAccountNumber = request.BankAccountNumber;
            customer.DateOfBirth = request.DateOfBirth;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }


}