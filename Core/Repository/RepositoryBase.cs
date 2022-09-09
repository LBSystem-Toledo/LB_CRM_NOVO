using Core.Context;
using Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public async Task AdicionarListaAsync(ICollection<T> entitys)
        {
            await _dbSet.AddRangeAsync(entitys);
        }

        public async Task AdicionarAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AlterarLista(ICollection<T> entitys)
        {
            _dbSet.UpdateRange(entitys);
        }

        public void Alterar(T entity)
        {
            _dbSet.Update(entity);
        }

        public void DeletarLista(ICollection<T> entitys)
        {

            _dbSet.RemoveRange(entitys);
        }

        public void Deletar(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            var query = _dbSet.AsQueryable<T>();
            if(filter != null)
                query = query
                    .Where(filter)
                    .AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<T?> GetEntityAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
