using encrypt_rsa.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Repository.Infra.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryEncryptRSA<UserModel>
    {
        Task<UserModel> GetUserByEmail(string email);
    }
}
