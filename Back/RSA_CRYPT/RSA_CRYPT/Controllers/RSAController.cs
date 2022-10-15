using Microsoft.AspNetCore.Mvc;
using RSA_CRYPT.BLL.Infra.Services.Interfaces;
using RSA_CRYPT.Models.Dto;

namespace RSA_CRYPT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RSAController : ControllerBase
    {
        private readonly IRSAService rsaService;
        public RSAController(IRSAService _rsaService)
        {
            rsaService = _rsaService;
        }
        [HttpPost]
        public async Task<IActionResult> TextEncrypt([FromBody] CryptDto text)
        {
            try
            {
                return await Task.FromResult(Ok(rsaService.EncryptText(text)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> TextDecrypt([FromBody] CryptDto text)
        {
            try
            {
                return await Task.FromResult(Ok(rsaService.DecryptText(text)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
