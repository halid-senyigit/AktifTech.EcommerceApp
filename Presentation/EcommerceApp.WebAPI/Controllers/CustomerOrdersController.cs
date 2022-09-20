using ECommerceApp.Application.DTOs.Common;
using ECommerceApp.Application.DTOs.CustomerOrderProductRel;
using ECommerceApp.Application.DTOs.CustomerOrders;
using ECommerceApp.Application.Features.CustomerOrderProductRel.Commands;
using ECommerceApp.Application.Features.CustomerOrders.Commands;
using ECommerceApp.Application.Features.CustomerOrders.Queries;
using ECommerceApp.Application.Features.Customers.Queries;
using ECommerceApp.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        [HttpGet("{orderId}", Name = "GetOrderById")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var query = new GetAllOrdersQuery(orderId);
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
            var products = await mediator.Send(new AddProductsToOrderCommand
            {
                CustomerOrderId = order.Result.Value, // CustomerOrderId
                OrderInformations = data.OrderInformations
            });

            return Ok(await mediator.Send(new GetAllOrdersQuery(order.Result.Value)));
        }


        /// <summary>
        /// 6. The client that is consuming the API must be able to delete a CustomerOrder via an endpoint.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            return Ok(await mediator.Send(new DeleteCustomerOrderCommand(orderId)));
        }

        // The client may change the product’s quantity ,add new product or remove a product from the CustomerOrder completely.


        /// <summary>
        /// // Customer may revise his/her address for the CustomerOrder.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(UpdateCustomerOrderAdressCommand data)
        {
            return Ok(await mediator.Send(data));
        }



    }
}
