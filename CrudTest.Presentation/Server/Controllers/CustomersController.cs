using CrudTest.Domain;
using CrudTest.Presentation.Shared.CQRS.Query.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Customer>> Get(CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new GetCustomerQuery(), cancellationToken);
            return customers;
        }
    }
}
