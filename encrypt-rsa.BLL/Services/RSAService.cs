using encrypt_rsa.BLL.Infra.Services.Interfaces;
using encrypt_rsa.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SharpRSA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace encrypt_rsa.BLL.Services
{
    public class RSAService : IRSAService
    {
        KeyPair kp = RSA.GenerateKeyPair(1024);
        public RSADto EncryptText(string password)
        {
            try
            {
                return Encrypt(password);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao criptografar texto");
            }
        }

        public RSADto Encrypt(string text)
        {
            List<int> ASCIIList = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                ASCIIList.Add(text[i]);
            }

            var bytes = ASCIIList.SelectMany(i => BitConverter.GetBytes(i)).ToArray();

            byte[] encrypted = RSA.EncryptBytes(bytes, kp.public_);

            byte[] decrypt = RSA.DecryptBytes(encrypted, kp.private_);

            var textoDescriptografado = Encoding.Default.GetString(decrypt).Replace("\u0000", "");

            RSADto res = new RSADto(encrypted, textoDescriptografado);

            return res;
        }
    }
}