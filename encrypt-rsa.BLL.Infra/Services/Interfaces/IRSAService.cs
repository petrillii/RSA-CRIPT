using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.BLL.Infra.Services.Interfaces
{
    public interface IRSAService
    {
        public string EncryptPassword(string password);
        public string DecryptPassword(string password);
        public bool ValidatePassword(string normalPassword, string rsaPassword);
    }
}
