using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediator.Domain.Commands;
using Mediator.Domain.Models;
using Mediator.Domain.Queries;
using MediatR;

namespace Mediator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EmployeesController> _logger;
        private readonly IMediator _mediator;

        public EmployeesController(ILogger<EmployeesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await _mediator.Send(new GetEmployeeListQuery());
        }

        [HttpGet("{id}")]
        public async Task<Employee> Get(Guid id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery(id));
        }

        [HttpPost]
        public async Task<Employee> Post([FromBody] Employee employee)
        {
            return await _mediator.Send(new AddEmployeeCommand(employee.FirstName, employee.LastName));
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _mediator.Send(new RemoveEmployeeCommand(id));
        }
    }
}
