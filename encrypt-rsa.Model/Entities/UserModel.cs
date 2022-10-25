using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Model.Entities
{
    [Table("Users")]
    public class UserModel
    {
        public UserModel(string name, string email)
        {
            Name = name;
            this.email = email;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public byte[] password { get; set; }
    }
}
