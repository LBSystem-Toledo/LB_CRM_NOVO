using Dominio;

namespace LB_CRM_API.Repositories.Interface
{
    public interface IPacoteRepository
    {
        Task<IEnumerable<Pacote>?> GetPacotesAsync(string? DsPacote);
        Task<Pacote?> GetPacoteAsync(int IdPacote);
        Task<bool> InsertOrUpdatePacoteAsync(Pacote pacote);
        Task<bool> InsertItemPacoteAsync(int IdPacote, int IdProcesso);
        Task<bool> DeletePacoteAsync(int IdPacote);
        Task<bool> DeleteItemPacoteAsync(int IdPacote, int IdProcesso);
    }
}
