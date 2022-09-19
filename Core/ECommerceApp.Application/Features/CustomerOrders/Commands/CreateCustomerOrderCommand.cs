using EcommerceApp.Domain.Entities;
using ECommerceApp.Application.DTOs.Common;
using ECommerceApp.Application.DTOs.CustomerOrders;
using ECommerceApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.CustomerOrders.Commands
{
    public class CreateCustomerOrderCommand : IRequest<ServiceWrapper<Integer>>
    {
        public CreateOrderDTO OrderInformations { get; set; } = new();

        public class CreateCustomerOrderCommandHandler : IRequestHandler<CreateCustomerOrderCommand, ServiceWrapper<Integer>>
        {

            private readonly ICustomerOrderRepository customerOrderRepository;

            public CreateCustomerOrderCommandHandler(ICustomerOrderRepository customerOrderRepository)
            {
                this.customerOrderRepository = customerOrderRepository;
            }

            // oluşturulan order'ın id'sini döner
            public async Task<ServiceWrapper<Integer>> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
            {
                var repoResult = await customerOrderRepository.AddAsync(new CustomerOrder
                {
                    CustomerId = request.OrderInformations.CustomerId,
                    Address = request.OrderInformations.Address
                });

                return new ServiceWrapper<Integer>(new Integer { Value = repoResult.Id });
            }
        }
    }
}
