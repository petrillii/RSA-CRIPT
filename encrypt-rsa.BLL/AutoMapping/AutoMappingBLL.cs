using AutoMapper;
using encrypt_rsa.Model.DTO;
using encrypt_rsa.Model.Entities;

namespace encrypt_rsa.BLL.AutoMapping
{
    public class AutoMappingBLL : Profile
    {
        public AutoMappingBLL()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
        }

    }
}
