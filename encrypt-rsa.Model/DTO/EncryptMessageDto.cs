using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Model.DTO
{
    public class EncryptMessageDto
    {
        public EncryptMessageDto(string text)
        {
            this.message = text;
        }
        public string message { get; set; }
    }
}
