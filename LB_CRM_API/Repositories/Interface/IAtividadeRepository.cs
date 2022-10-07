using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IAtividadeRepository
    {
        Task<IEnumerable<Atividade>?> GetAtividadesAsync(string? DsAtividade);
        Task<Atividade?> GetAtividadeAsync(int IdAtividade);
        Task<bool> InsertOrUpdateAtividadeAsync(Atividade atividade);
        Task<bool> DeleteAtividadeAsync(int IdAtividade);
    }
}
