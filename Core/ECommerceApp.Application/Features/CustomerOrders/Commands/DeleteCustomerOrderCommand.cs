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
    public class DeleteCustomerOrderCommand : IRequest<ServiceWrapper<Integer>>
    {
        public int CustomerOrderId { get; set; }

        public DeleteCustomerOrderCommand(int customerOrderId)
        {
            CustomerOrderId = customerOrderId;
        }

        public class DeleteCustomerOrderCommandHandler : IRequestHandler<DeleteCustomerOrderCommand, ServiceWrapper<Integer>>
        {

            private readonly ICustomerOrderRepository customerOrderRepository;

            public DeleteCustomerOrderCommandHandler(ICustomerOrderRepository customerOrderRepository)
            {
                this.customerOrderRepository = customerOrderRepository;
            }

            public async Task<ServiceWrapper<Integer>> Handle(DeleteCustomerOrderCommand request, CancellationToken cancellationToken)
            {
                var repoResult = await customerOrderRepository.RemoveAsync(request.CustomerOrderId);

                return new ServiceWrapper<Integer>(new Integer { Value = repoResult });
            }
        }
    }
}
