using ECommerceApp.Application.DTOs.CustomerOrders;
using ECommerceApp.Application.Features.CustomerOrders.Commands;
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


        /// <summary>
        /// 5. The client that is consuming the API must be able to save a CustomerOrder via an endpoint.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateCustomerOrderCommand data)
        {
            var order = await mediator.Send(data);
            return Ok(order);
        }


        /// <summary>
        /// 6. The client that is consuming the API must be able to delete a CustomerOrder via an endpoint.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder()
        {
            return Ok("DeleteOrder");
        }

        // The client may change the product’s quantity

        // add new product or remove a product from the CustomerOrder completely.
        // Customer may revise his/her address for the CustomerOrder.



    }
}
