using AutoMapper;
using ECommerceApp.Application.DTOs.Common;
using ECommerceApp.Application.DTOs.Customers;
using ECommerceApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<ServiceWrapper<List<GetAllCustomersDTO>>>
    {

    }

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ServiceWrapper<List<GetAllCustomersDTO>>>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceWrapper<List<GetAllCustomersDTO>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await customerRepository.GetAllAsync();
            var mapped = mapper.Map<List<GetAllCustomersDTO>>(customers);
            var result = new ServiceWrapper<List<GetAllCustomersDTO>>(mapped);

            return result;
        }
    }
}
