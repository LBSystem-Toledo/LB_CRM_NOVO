using Dominio;

namespace LB_CRM_API.Services.Interface
{
    public interface IClienteService
    {
        Task<Cliente?> GetClienteAsync(int IdCliente);
        Task<IEnumerable<Cliente>?> GetClientesAsync(string? Nome, int? IdAtividade, int? IdParceiro);
        Task<bool> InsertOrUpdateAsync(Cliente cliente);
        Task<bool> InativarClienteAsync(Cliente cliente);
    }
}
