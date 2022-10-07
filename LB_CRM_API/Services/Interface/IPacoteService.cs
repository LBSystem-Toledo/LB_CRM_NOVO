using Dominio;

namespace LB_CRM_API.Services.Interface
{
    public interface IPacoteService
    {
        Task<Pacote?> GetPacoteAsync(int IdPacote);
        Task<IEnumerable<Pacote>?> GetPacotesAsync(string? DsPacote);
        Task<bool> InsertOrUpdatePacoteAsync(Pacote pacote);
        Task<bool> DeletePacoteAsync(int IdPacote);
    }
}
