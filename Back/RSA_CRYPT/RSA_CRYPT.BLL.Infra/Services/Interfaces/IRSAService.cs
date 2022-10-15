using RSA_CRYPT.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_CRYPT.BLL.Infra.Services.Interfaces
{
    public interface IRSAService
    {
        string EncryptText(CryptDto text);
        string DecryptText(CryptDto encryptText);
    }
}
