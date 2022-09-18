using ECommerceApp.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderRepository customerOrderRepository;

        public CustomerOrderController(ICustomerOrderRepository customerOrderRepository)
        {
            this.customerOrderRepository = customerOrderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var a = await customerOrderRepository.GetAll();
            return Ok("test");
        }
    }
}
