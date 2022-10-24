using encrypt_rsa.BLL.Infra.Services.Interfaces;
using encrypt_rsa.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace encrypt_rsa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RSAController : ControllerBase
    {
        private readonly IRSAService rsaService;
        private readonly ILogger<RSAController> _logger;

        public RSAController(
            ILogger<RSAController> logger,
            IRSAService _rsaService
        )
        {
            _logger = logger;
            rsaService = _rsaService;
        }

        [HttpPost("Criptografar")]
        public async Task<ActionResult<string>> EncryptRSA(string msg)
        {
            try
            {
                return rsaService.EncryptPassword(msg);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpPost("Descriptografar")]
        public async Task<ActionResult<string>> DecryptRSA(string msg)
        {
            try
            {
                return rsaService.DecryptPassword(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}