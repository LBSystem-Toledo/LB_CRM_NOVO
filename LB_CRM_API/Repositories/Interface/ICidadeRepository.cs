using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface ICidadeRepository
    {
        Task<IEnumerable<Cidade>?> GetCidadesAsync(string? DsCidade,
                                                   string? Uf);
        Task<Cidade?> GetCidadeAsync(int IdCidade);
        Task<bool> InsertOrUpdateCidadeAsync(Cidade cidade);
        Task<bool> DeleteCidadeAsync(int IdCidade);
    }
}
