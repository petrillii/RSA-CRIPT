using encrypt_rsa.BLL.Infra.Services.Interfaces;
using encrypt_rsa.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace encrypt_rsa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RSAController : ControllerBase
    {
        private readonly IEncryptService encryptService;
        private readonly IDecryptService decryptService;
        private readonly ILogger<RSAController> _logger;

        public RSAController(
            ILogger<RSAController> logger,
            IEncryptService _encryptService,
            IDecryptService _decryptService
        )
        {
            _logger = logger;
            encryptService = _encryptService;
            decryptService = _decryptService;
        }

        [HttpPost("Criptografar")]
        public async Task<ActionResult<EncryptMessageDto>> EncryptRSA([FromBody] ConfigRSADto config)
        {
            try
            {
                return encryptService.EncryptMessage(config);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpPost("Descriptografar")]
        public async Task<ActionResult<EncryptMessageDto>> DecryptRSA([FromBody] ConfigRSADto config)
        {
            try
            {
                return decryptService.DecryptMessage(config);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}