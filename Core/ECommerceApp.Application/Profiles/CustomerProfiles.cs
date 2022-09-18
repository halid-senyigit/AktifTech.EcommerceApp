using AutoMapper;

namespace ECommerceApp.Application.Profiles
{
    public class CustomerProfiles : Profile
    {
        public CustomerProfiles()
        {
            CreateMap<EcommerceApp.Domain.Entities.Customer, DTOs.Customers.GetAllCustomersDTO>().ReverseMap();
        }

    }
}
