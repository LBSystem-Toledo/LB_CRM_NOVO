using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IParceiroRepository
    {
        Task<IEnumerable<Parceiro>?> GetParceirosAsync(string? Nome);
        Task<Parceiro?> GetParceiroAsync(int IdParceiro);
        Task<bool> InsertOrUpdateParceiroAsync(Parceiro parceiro);
        Task<bool> DeleteParceiroAsync(int IdParceiro);
    }
}
