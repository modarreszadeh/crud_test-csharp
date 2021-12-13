using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Presentation.Shared.CQRS.Query.Customer
{
    public class GetCustomerQuery : IRequest<List<CrudTest.Domain.Models.Customer>>
    {
    }
}
