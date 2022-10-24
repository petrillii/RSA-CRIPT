using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Repository.Infra.Repositories.Interfaces
{
    public interface IRepositoryEncryptRSA<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<int> Delete(TEntity entity);
        Task<int> Create(TEntity entity);
        Task<int> Update(TEntity entidade);
    }
}
