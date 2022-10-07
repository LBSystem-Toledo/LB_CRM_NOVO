using System.Data;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>?> GetAllAsync(string sql, object? param = null);
        Task<T?> GetAsync(string sql, object? param = null);
        Task<bool> ExecuteAsync(string comando, object param, CommandType commandType);
    }
}
