using encrypt_rsa.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.BLL.Infra.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserDto user);
        Task<UserDto> AuthenticateUser(AuthenticateUserDto user);
    }
}
