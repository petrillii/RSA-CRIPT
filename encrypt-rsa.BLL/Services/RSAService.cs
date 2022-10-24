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
        const int P = 17;
        const int Q = 23;
        const int N = (P * Q);
        const int totienteN = (P - 1) * (Q - 1);
        const int E = 3;
        public string EncryptPassword(string password)
        {
            int D = PrivateKey();
            try
            {
                return Encrypt(password);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao criptografar texto");
            }
        }
        public string DecryptPassword(string password)
        {
            int D = PrivateKey();
            try
            {
                return Decrypt(password, D);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao descriptografar o text");
            }
        }

        public bool ValidatePassword(string normalPassword, string rsaPassword)
        {
            throw new NotImplementedException();
        }

        public int PrivateKey()
        {
            int d = 0;
            while ((d * E) % totienteN != 1)
            {
                d += 1;
            }
            return d;
        }

        public string Encrypt(string text)
        {
            byte[] raw;
            string msg = "";
            List<int> ASCIIList = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                ASCIIList.Add(text[i]);
            }
            foreach (int obj in ASCIIList)
            {
                int ascii = obj;
                int k = Convert.ToInt32(Math.Pow(ascii, (double)E) % N);
                msg += Convert.ToChar(k);
            }
            return msg;
        }

        public string Decrypt(string encryptText, int D)
        {
            string decryptText = "";

            List<int> listDecrypt = new List<int>();

            for (int i = 0; i < encryptText.Length; i++)
            {
                listDecrypt.Add(encryptText[i]);
            }
            foreach (int obj in listDecrypt)
            {
                int ascii = obj;
                int k = Convert.ToInt32(Math.Pow(ascii, (double)D) % N);
                decryptText += (char)k;
            }
            return decryptText;
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
