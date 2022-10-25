using encrypt_rsa.BLL.Infra.Services.Interfaces;
using encrypt_rsa.Model.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace encrypt_rsa.BLL.Services
{
    public class RSAService : IRSAService
    {
        public RSADto EncryptText(string text)
        {
            try
            {
                return Encrypt(text);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao criptografar texto");
            }
        }

        public RSADto Encrypt(string text)
        {
            const int P = 17;
            const int Q = 19;
            const int N = (P * Q);
            const int totienteN = (P - 1) * (Q - 1);
            int E = GeneratePublicKey(totienteN, N);
            int D = PrivateKey(totienteN, E);

            List<int> ASCIIList = new List<int>();
            List<int> cryptList = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                ASCIIList.Add(text[i]);
            }
            foreach (int obj in ASCIIList)
            {
                int ascii = obj;
                cryptList.Add(Convert.ToInt32(Math.Pow(ascii, (double)E) % N));
            }

            byte[] bytes = cryptList.SelectMany(i => BitConverter.GetBytes(i)).ToArray();

            string textDecrypt = Decrypt(bytes, N, D);

            RSADto rsaMsg = new RSADto(bytes, textDecrypt);

            return rsaMsg;
        }

        public string Decrypt(byte[] text, int N, int D)
        {
            List<int> listDecrypt = new List<int>();
            List<int> textDecrypt = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                listDecrypt.Add(text[i]);
            }
            foreach (int obj in listDecrypt)
            {
                int ascii = obj;
                double k = (Convert.ToInt32(Math.Pow(ascii, (double)D) % N));
                textDecrypt.Add((int)k);
            }

            byte[] bytes = textDecrypt.SelectMany(i => BitConverter.GetBytes(i)).ToArray();
            string textoDescriptografado = Encoding.Default.GetString(bytes).Replace("\u0000", "");

            return textoDescriptografado;
        }

        public int GeneratePublicKey(int totienteN, int N)
        {
            while (true)
            {
                Random numRandom = new Random();
                int e = numRandom.Next(2, N);
                if (Mdc(N, e) == 1)
                {
                    return e;
                }
            }
        }

        public int PrivateKey(int totiente, int E)
        {
            int d = 0;
            while ((d * E) % totiente != 1)
            {
                d += 1;
            }
            return d;
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