using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DebtNote
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

            CreateMap<UserForCreationDTO, User>();
            CreateMap<UserItemReferenceForCreationDTO, UserItemReference>();
            CreateMap<SkuForCreationDTO, Sku>();
            CreateMap<PaymentForCreationDTO, Payment>();
            CreateMap<PaymentItemForCreationDTO, PaymentItem>();

            CreateMap<UserForUpdateDTO, User>();
            CreateMap<UserItemReferenceForUpdateDTO, UserItemReference>();
            CreateMap<SkuForUpdateDTO, Sku>();
            CreateMap<PaymentForUpdateDTO, Payment>();
            CreateMap<PaymentItemForUpdateDTO, PaymentItem>();
        }
    }
}
