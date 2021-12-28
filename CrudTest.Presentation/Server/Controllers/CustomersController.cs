using CrudTest.Domain.Models;
using CrudTest.Presentation.Shared.Api;
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

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResult<List<Customer>>> Get(CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new GetCustomerQuery(), cancellationToken);
            return customers;
        }

        [HttpPost]
        public async Task<ApiResult> Post(AddCustomerCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newCustomer = await _mediator.Send(command, cancellationToken);
            return Ok("Customer added successfully");
        }

        [HttpDelete("{id:int}")]
        public async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            var customer = await _mediator.Send(new DeleteCustomerCommand { Id = id }, cancellationToken);
            return Ok("Customer deleted successfully");
        }

        [HttpPut]
        public async Task<ApiResult> Put(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var updatedCustomer = await _mediator.Send(command, cancellationToken);
            return Ok("Customer updated successfully");
        }
    }
}
