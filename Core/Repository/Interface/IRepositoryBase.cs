using System.Linq.Expressions;

namespace Core.Repository.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T?> GetEntityAsync(int id);
        Task AdicionarListaAsync(ICollection<T> entitys);
        Task AdicionarAsync(T entity);
        void AlterarLista(ICollection<T> entitys);
        void Alterar(T entity);
        void DeletarLista(ICollection<T> entitys);
        void Deletar(T entity);
    }
}
