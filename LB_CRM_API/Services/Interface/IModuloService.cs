using Dominio;

namespace LB_CRM_API.Services.Interface
{
    public interface IModuloService
    {
        Task<Modulo?> GetModuloAsync(int IdModulo);
        Task<IEnumerable<Modulo>?> GetModulosAsync(string? DsModulo);
        Task<bool> InsertOrUpdateAsync(Modulo modulo);
        Task<bool> DeleteAsync(int IdModulo);
    }
}
