using ECommerceApp.Application.Features.Customers.Queries;
using ECommerceApp.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerOrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCustomersQuery();
            return Ok(await mediator.Send(query));
        }

    }
}
