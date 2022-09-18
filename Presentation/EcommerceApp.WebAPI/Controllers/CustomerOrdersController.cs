using ECommerceApp.Application.Features.CustomerOrders.Queries;
using ECommerceApp.Application.Features.Customers.Queries;
using ECommerceApp.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebAPI.Controllers
{
    /// <summary>
    /// Orders -> create|edit|delete
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerOrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var query = new GetAllOrdersQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            return Ok("test");
        }

    }
}
