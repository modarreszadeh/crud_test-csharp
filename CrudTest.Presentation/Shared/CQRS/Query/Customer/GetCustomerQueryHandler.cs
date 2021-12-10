using CrudTest.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Presentation.Shared.CQRS.Query.Customer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<CrudTest.Domain.Customer>>
    {
        private readonly AppDbContext _context;

        public GetCustomerQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers.ToListAsync(cancellationToken);
        }
    }
}
