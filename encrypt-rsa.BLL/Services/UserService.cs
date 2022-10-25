using AutoMapper;
using encrypt_rsa.BLL.Infra.Services.Interfaces;
using encrypt_rsa.Model.DTO;
using encrypt_rsa.Model.Entities;
using encrypt_rsa.Repository.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;
        private readonly IMapper mapper;
        private readonly IRSAService rsaService;
        public UserService(IUserRepository _userRepo, IMapper _mapper, IRSAService _rsaService)
        {
            userRepo = _userRepo;
            mapper = _mapper;
            rsaService = _rsaService;
        }
        public async Task<UserDto> AuthenticateUser(AuthenticateUserDto user)
        {
            UserModel _userEntity = await userRepo.GetUserByEmail(user.email);

            if (_userEntity == null)
            {
                throw new ArgumentException("Email ou senha incorretos!");
            }

            UserDto _user = mapper.Map<AuthenticateUserDto, UserDto>(user);

            _user.password = rsaService.EncryptText(_userEntity.password.ToString()).TextoDescriptografado;

            if (_userEntity.password.ToString() != _user.password.ToString())
            {
                throw new ArgumentException("Email ou senha incorretos!");
            }

            return await Task.FromResult(_user);

            throw new NotImplementedException();
        }

        public async Task CreateUser(UserDto user)
        {
            UserModel _userEntity = await userRepo.GetUserByEmail(user.email);
            if (_userEntity != null)
            {
                throw new ArgumentException("Usuário com email já cadastrado!");
            }
            UserModel _user = new UserModel(user.name, user.email);
            _user.password = rsaService.EncryptText(user.password).TextoCriptografado;
            await userRepo.Create(_user);
        }
    }
}
