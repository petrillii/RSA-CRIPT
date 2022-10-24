using AutoMapper;
using encrypt_rsa.Model.DTO;
using encrypt_rsa.Model.Entities;

namespace encrypt_rsa.Infra.AutoMapper
{
    public class MappingModel : Profile
    {
        public MappingModel()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserDto, AuthenticateUserDto>().ReverseMap();
        }
    }
}
