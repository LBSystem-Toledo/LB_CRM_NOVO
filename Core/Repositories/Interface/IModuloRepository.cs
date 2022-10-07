using Dominio;

namespace Core.Repository.Interface
{
    public interface IModuloRepository
    {
        Task<IEnumerable<Modulo>?> GetModulosAsync(string? ds_modulo);
        Task<Modulo?> GetModuloAsync(int id);
        Task<bool> InsertModuloAsync(Modulo modulo);
        Task<bool> UpdateModuloAsync(Modulo modulo);
        Task<bool> DeleteModuloAsync(int id);
    }
}
