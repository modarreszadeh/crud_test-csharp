using CrudTest.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Presentation.Shared.CQRS.Query.Customer
{
    public class CustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<CrudTest.Domain.Models.Customer>>
    {
        private readonly AppDbContext _context;

        public CustomerQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CrudTest.Domain.Models.Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers.ToListAsync(cancellationToken);
        }
    }
}
