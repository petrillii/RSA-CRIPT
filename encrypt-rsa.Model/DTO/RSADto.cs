using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Model.DTO
{
    public class RSADto
    {
        public RSADto(byte[] textCrypt, string textDecrypt)
        {
            TextoCriptografado = textCrypt;
            TextoDescriptografado = textDecrypt;
        }
        public byte[] TextoCriptografado { get; set; }
        public string TextoDescriptografado { get; set; }
    }
}
