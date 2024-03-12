using AutoMapper;
using SQRS.Medium.Application.UserCases.MediumUser.Commands;
using SQRS.Medium.Domain.Entities;

namespace SQRS.Medium.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
