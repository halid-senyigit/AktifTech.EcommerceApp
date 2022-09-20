using ECommerceApp.Application.DTOs.Common;
using ECommerceApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.CustomerOrders.Commands
{
    public class UpdateCustomerOrderAdressCommand : IRequest<ServiceWrapper<OnlyMessage>>
    {
        public int CustomerOrderId { get; set; }
        public string Address { get; set; }

        public class UpdateCustomerOrderAdressCommandHandler : IRequestHandler<UpdateCustomerOrderAdressCommand, ServiceWrapper<OnlyMessage>>
        {
            private readonly ICustomerOrderRepository customerOrderRepository;

            public UpdateCustomerOrderAdressCommandHandler(ICustomerOrderRepository customerOrderRepository)
            {
                this.customerOrderRepository = customerOrderRepository;
            }
            public async Task<ServiceWrapper<OnlyMessage>> Handle(UpdateCustomerOrderAdressCommand request, CancellationToken cancellationToken)
            {
                var order = await customerOrderRepository.GetByIdAsync(request.CustomerOrderId);
                if (order != null)
                {
                    order.Address = request.Address;
                    await customerOrderRepository.UpdateAsync(order);
                }


                return new ServiceWrapper<OnlyMessage>(new OnlyMessage()) { Message = "updated"};
            }
        }
    }
}
