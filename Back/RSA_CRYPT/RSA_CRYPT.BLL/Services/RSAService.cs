using RSA_CRYPT.BLL.Infra.Services.Interfaces;
using RSA_CRYPT.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_CRYPT.BLL.Services
{
    public class RSAService : IRSAService
    {
        public string EncryptText(CryptDto text)
        {

            return "a";
        }
        public string DecryptText(CryptDto encryptText)
        {
            throw new NotImplementedException();
        }
    }
}
