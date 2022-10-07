using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IUsuarioClienteRepository
    {
        Task<IEnumerable<UsuarioCliente>?> GetAllAsync(int? IdCliente);
        Task<bool> InsertOrUpdateAsync(UsuarioCliente usuario);
    }
}
