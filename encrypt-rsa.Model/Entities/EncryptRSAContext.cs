using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Model.Entities
{
    public class EncryptRSAContext : DbContext
    {
        #region Base
        public EncryptRSAContext(DbContextOptions<EncryptRSAContext> options) : base(options)
        {
        }

        public void AddEntity(object entity)
        {
            base.Add(entity);
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #region DbSets
        public virtual DbSet<UserModel> users { get; set; }
        #endregion

    }
}
