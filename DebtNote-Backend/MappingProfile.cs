using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DebtNote_Backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserItemReference, UserItemReferenceDTO>();
            CreateMap<Sku, SkuDTO>();
            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentItem, PaymentItemDTO>();
        }
    }
}
