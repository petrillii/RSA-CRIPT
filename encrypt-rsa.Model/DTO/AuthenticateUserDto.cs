using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Model.DTO
{
    public class AuthenticateUserDto
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
