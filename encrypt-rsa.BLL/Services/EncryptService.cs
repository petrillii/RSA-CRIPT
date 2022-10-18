using encrypt_rsa.BLL.Infra.Services.Interfaces;
using encrypt_rsa.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.BLL.Services
{
    public class EncryptService : IEncryptService
    {
        Random numRandom = new Random();

        public EncryptService()
        {
            
        }
        public EncryptMessageDto EncryptMessage(ConfigRSADto config)
        {
            ConfigRSADto configRSADto = config;
            GeneratePublicKey(configRSADto.totiente);

            EncryptMessageDto encryptedMessage = new EncryptMessageDto(Encrypt(configRSADto));
            
            return encryptedMessage;
        }

        public int GeneratePublicKey(int totiente)
        {
            int e = numRandom.Next(2, totiente);
            if (Mdc(totiente, 2) == 1)
            {
                return e;
            }
            throw new ArgumentException("Valor de totiente inválido");
        }

        public string Encrypt(ConfigRSADto configs)
        {
            List<char> ASCIIList = new List<char>();

            for (int i = 0; i < configs.message.Length; i++)
            {
                ASCIIList.Add(configs.message[i]);
            }
            foreach (char obj in ASCIIList)
            {
                double ascii = (int)obj;
                double k = Math.Pow(ascii, (double)configs.e) % configs.n;
                configs.message += (char)k;
            }
            return configs.message;
        }

        public int Mdc(int n1, int n2)
        {
            while (n2 != 0)
            {
                int r = n1 % n2;
                n1 = n2;
                n2 = r;
            }
            return n1;
        }
    }
}
