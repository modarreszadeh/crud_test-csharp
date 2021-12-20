using CrudTest.Domain.Models;
using CrudTest.Presentation.Shared.CQRS.Query.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS.Command.Customer;
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
        private readonly AppDbContext _context;

        public CustomersController(IMediator mediator,AppDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }
        
        [HttpGet]
        public async Task<List<Customer>> Get(CancellationToken cancellationToken)
        {
            // return await _context.Customers.ToListAsync(cancellationToken);
            var customers = await _mediator.Send(new GetCustomerQuery(), cancellationToken);
            return customers;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddCustomerCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newCustomer = await _mediator.Send(command, cancellationToken);
            return Ok("Customer added successfully");
        }
    }
}
