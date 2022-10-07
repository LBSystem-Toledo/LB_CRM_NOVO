using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IClienteProcessoRepository
    {
        Task<IEnumerable<ClienteProcesso>?> GetAllAsync(int IdCliente);
        Task<bool> InsertOrUpdateAsync(ClienteProcesso clienteProcessos);
    }
}
