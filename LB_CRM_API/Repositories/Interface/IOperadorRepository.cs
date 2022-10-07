using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IOperadorRepository
    {
        Task<IEnumerable<Operador>?> GetAllAsync(int IdParceiro);
        Task<Operador?> GetAsync(int IdParceiro, int IdOperador);
        Task<bool> InsertOrUpdateAsync(Operador operador);
        Task<bool> DeleteAsync(int IdParceiro, int IdOperador);
    }
}
