using ECommerceApp.Application.DTOs.Common;
using ECommerceApp.Application.DTOs.Customers;
using ECommerceApp.Application.DTOs.Orders;
using ECommerceApp.Application.Features.Customers.Queries;
using ECommerceApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.CustomerOrders.Queries
{
    public class GetAllOrdersQuery: IRequest<ServiceWrapper<List<GetOrderListDTO>>>
    {
    }

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ServiceWrapper<List<GetOrderListDTO>>>
    {
        private readonly ICustomerOrderRepository customerOrderRepository;

        public GetAllOrdersQueryHandler(ICustomerOrderRepository customerOrderRepository)
        {
            this.customerOrderRepository = customerOrderRepository;
        }

        public async Task<ServiceWrapper<List<GetOrderListDTO>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await customerOrderRepository.GetAllCustomerOrdersWithProductsAsync();
            var result = new ServiceWrapper<List<GetOrderListDTO>>(orders.Select(n => new GetOrderListDTO
            {
                OrderId = n.Id,
                Products = n.CustomerOrderProductRels.Select(x => new GetOrderListDTO.ProductDTO
                {
                    ProductId = x.ProductId,
                    Name = x.Product.Name,
                    Price = x.Product.Price
                }).ToList()
            }).ToList());

            return result;
        }
    }
}
