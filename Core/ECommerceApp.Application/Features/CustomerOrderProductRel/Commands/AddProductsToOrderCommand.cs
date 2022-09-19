using EcommerceApp.Domain.Entities;
using ECommerceApp.Application.DTOs.Common;
using ECommerceApp.Application.DTOs.CustomerOrderProductRel;
using ECommerceApp.Application.DTOs.CustomerOrders;
using ECommerceApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.CustomerOrderProductRel.Commands
{
    public class AddProductsToOrderCommand : IRequest<ServiceWrapper<Integer>>
    {
        public CreateOrderDTO OrderInformations { get; set; } = new();
        public int CustomerOrderId { get; set; }

        public class AddProductsToOrderCommandHandler : IRequestHandler<AddProductsToOrderCommand, ServiceWrapper<Integer>>
        {
            private readonly ICustomerOrderProductRelRepository customerOrderProductRelRepository;

            public AddProductsToOrderCommandHandler(ICustomerOrderProductRelRepository customerOrderProductRelRepository)
            {
                this.customerOrderProductRelRepository = customerOrderProductRelRepository;
            }

            public async Task<ServiceWrapper<Integer>> Handle(AddProductsToOrderCommand request, CancellationToken cancellationToken)
            {
                List<EcommerceApp.Domain.Entities.CustomerOrderProductRel> orderProducts = new List<EcommerceApp.Domain.Entities.CustomerOrderProductRel>();

                foreach (var item in request.OrderInformations.Products)
                {
                    orderProducts.Add(new EcommerceApp.Domain.Entities.CustomerOrderProductRel
                    {
                        CustomerOrderId = request.CustomerOrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    });
                }

                var repoResult = await customerOrderProductRelRepository.AddRangeAsync(orderProducts);
                return new ServiceWrapper<Integer>(new Integer { Value = repoResult != null ? repoResult.Count() : 0 });
            }
        }
    }
}
