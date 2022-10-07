using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IModuloRepository
    {
        Task<IEnumerable<Modulo>?> GetModulosAsync(string? dsmodulo);
        Task<Modulo?> GetModuloAsync(int id);
        Task<bool> InsertOrUpdateModuloAsync(Modulo modulo);
        Task<bool> DeleteModuloAsync(Modulo modulo);
    }
}
