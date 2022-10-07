using Dominio;

namespace LB_CRM_API.Services.Interface
{
    public interface IParceiroService
    {
        Task<IEnumerable<Parceiro>?> GetParceirosAsync(string? Nome);
        Task<Parceiro?> GetParceiroAsync(int IdParceiro);
        Task<bool> InsertOrUpdateParceiroAsync(Parceiro parceiro);
        Task<bool> InativarParceiroAsync(Parceiro parceiro);
    }
}
