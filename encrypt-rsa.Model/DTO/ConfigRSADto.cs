using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Model.DTO
{
    public class ConfigRSADto
    {
        public ConfigRSADto(int p, int q, int d, int n, int totiente, int e)
        {
            this.p = p;
            this.q = q;
            this.d = d;
            this.n = p * q;
            this.totiente = (q - 1) * (p - 1);
            this.e = e;
        }
        public string message { get; set; }
        public int p { get; set; }
        public int q { get; set; }
        public int d { get; set; }
        public int n { get; set; }
        public int e { get; set; }
        public int totiente { get; set; }
    }
}
