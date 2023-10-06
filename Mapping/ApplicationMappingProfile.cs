using AutoMapper;
using SimpleApi.Models.Dto;
using SimpleApi.Models.Entities;

namespace SimpleApi.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<CreateUserDto, UserEntity>();
            CreateMap<UpdateUserDto, UserEntity>();
        }
    }
}
