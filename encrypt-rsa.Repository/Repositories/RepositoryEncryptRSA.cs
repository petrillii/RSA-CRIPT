using encrypt_rsa.Model.Entities;
using encrypt_rsa.Repository.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.Repository.Repositories
{
    /// <summary>
    /// Metodo usado para herança somente de entidades no banco e não para entidades compostas
    /// </summary>
    /// <typeparam name="TEntity">Entidade generica representando uma tabela no banco</typeparam>
    public class RepositoryEncryptRSA<TEntity>: IRepositoryEncryptRSA<TEntity> where TEntity : class
    {
        protected readonly EncryptRSAContext _ctx;

        /// <summary>
        /// Utilizado somente para Injeção de Dependência.
        /// </summary>
        /// <param name="ctx">Contexto de conexão do banco gerenciado somente pela Injeção de Dependência.</param>
        public RepositoryEncryptRSA(EncryptRSAContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Obtem entidade pelo Id Chave primária da tabela.
        /// </summary>
        /// <param name="id">Chave primária ID.</param>
        /// <returns>Entidade correspondente.</returns>
        public Task<TEntity> GetById(int id)
        {
            return Task.Run(() => _ctx.Set<TEntity>().Find(id));
        }

        /// <summary>
        /// Adiciona a entidade.
        /// </summary>
        /// <param name="entidade">Entidade relacionada a tabela.</param>
        /// <returns>Numero de linhas afetadas</returns>
        public Task<int> Create(TEntity entidade)
        {
            _ctx.Set<TEntity>().Add(entidade);
            return _ctx.SaveChangesAsync();
        }

        /// <summary>
        /// Remove entidade no banco.
        /// </summary>
        /// <param name="entidade">Entidade a ser removida do banco, necessário ter o ID primário preenchido.</param>
        /// <returns>Número de linhas afetadas no banco.</returns>
        public Task<int> Remover(TEntity entidade)
        {
            _ctx.Set<TEntity>().Remove(entidade);
            return _ctx.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza entidade no banco.
        /// </summary>
        /// <param name="entidade">Entidade a ser atualizada, necessário ter o ID primário preenchido.</param>
        /// <returns>Número de linhas afetadas no banco.</returns>
        public Task<int> Update(TEntity entidade)
        {
            _ctx.Set<TEntity>().Update(entidade);
            return _ctx.SaveChangesAsync();
        }

        /// <summary>
        /// Remove entidade no banco.
        /// </summary>
        /// <param name="entidade">Entidade a ser removida do banco, necessário ter o ID primário preenchido.</param>
        /// <returns>Número de linhas afetadas no banco.</returns>
        public Task<int> Delete(TEntity entidade)
        {
            _ctx.Set<TEntity>().Remove(entidade);
            return _ctx.SaveChangesAsync();
        }

    }
}
