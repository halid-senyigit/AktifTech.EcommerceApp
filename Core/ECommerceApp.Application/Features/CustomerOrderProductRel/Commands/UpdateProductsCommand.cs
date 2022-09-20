using ECommerceApp.Application.DTOs.Common;
using ECommerceApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.CustomerOrderProductRel.Commands
{
    public class UpdateProductsCommand : IRequest<ServiceWrapper<OnlyMessage>>
    {

        public int CustomerOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


        public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand, ServiceWrapper<OnlyMessage>>
        {
            private readonly ICustomerOrderProductRelRepository customerOrderProductRelRepository;

            public UpdateProductsCommandHandler(ICustomerOrderProductRelRepository customerOrderProductRelRepository)
            {
                this.customerOrderProductRelRepository = customerOrderProductRelRepository;
            }

            public async Task<ServiceWrapper<OnlyMessage>> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
            {
                var productRels = await customerOrderProductRelRepository.GetByQueryAsync(n => n.ProductId == request.ProductId && n.CustomerOrderId == request.CustomerOrderId);
                if (productRels.Count() == 0 && request.Quantity > 0)
                {
                    await customerOrderProductRelRepository.AddAsync(new EcommerceApp.Domain.Entities.CustomerOrderProductRel
                    {
                        ProductId = request.ProductId,
                        Quantity = request.Quantity,
                        CustomerOrderId = request.CustomerOrderId
                    });
                }
                else
                {
                    var productRel = productRels.FirstOrDefault();
                    if (request.Quantity > 0)
                    {
                        productRel.Quantity = request.Quantity;
                        await customerOrderProductRelRepository.UpdateAsync(productRel);
                    }
                    else
                    {
                        await customerOrderProductRelRepository.RemoveAsync(productRel.Id);
                    }
                }

                return new ServiceWrapper<OnlyMessage>(new OnlyMessage()) { Message = "updated" };
            }
        }

    }
}
