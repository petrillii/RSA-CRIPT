using AutoMapper;
using encrypt_rsa.Model.Entities;
using encrypt_rsa.Repository.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Repository.Repositories
{
    public class UserRepository : RepositoryEncryptRSA<UserModel>, IUserRepository
    {
        private readonly EncryptRSAContext db;
        private readonly IMapper mapper;
        public UserRepository(EncryptRSAContext ctx) : base(ctx)
        {
         
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _ctx.users.FirstOrDefaultAsync(x => x.email.ToLower() == email.ToLower());
        }
    }
}
