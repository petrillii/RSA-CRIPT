using encrypt_rsa.BLL.Infra.Services.Interfaces;
using encrypt_rsa.BLL.Services;
using encrypt_rsa.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace encrypt_rsa.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserDto user)
        {
            try
            {
                await _userService.AuthenticateUser(user);
                return await Task.FromResult(Ok("Usuário autenticado com sucesso!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserDto user)
        {
            try
            {
                await _userService.CreateUser(user);
                return await Task.FromResult(Ok("Usuário cadastrado com sucesso"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
