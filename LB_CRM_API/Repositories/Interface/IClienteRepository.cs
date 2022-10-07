using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>?> GetAllAsync(string? Nome, int? IdAtividade, int? IdParceiro);
        Task<Cliente?> GetAsync(int IdCliente);
        Task<bool> InsertOrUpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(int IdCliente);
    }
}
