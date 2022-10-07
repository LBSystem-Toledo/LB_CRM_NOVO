using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IProcessoRepository
    {
        Task<IEnumerable<Processo>?> GetProcessosAsync(string? dsprocesso = null,
                                                       string? complemento = null,
                                                       int? IdModulo = null);
        Task<IEnumerable<Processo>?> GetProcessosPacoteAsync(int IdPacote);
        Task<Processo?> GetProcessoAsync(int id);
        Task<bool> InsertOrUpdateProcessoAsync(Processo processo);
        Task<bool> DeleteProcessoAsync(int id);
    }
}