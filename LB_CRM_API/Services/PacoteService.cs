using Dominio;
using LB_CRM_API.Services.Interface;
using LB_CRM_API.UnitOfWork;

namespace LB_CRM_API.Services
{
    public class PacoteService : IPacoteService
    {
        readonly IUnitOfCRM _banco;
        public PacoteService(IUnitOfCRM banco) { _banco = banco; }

        public async Task<bool> DeletePacoteAsync(int IdPacote)
        {
            try
            {
                if (await _banco.BeginTransactionAsync())
                {
                    Pacote? pacote = await _banco.PacoteRepository.GetPacoteAsync(IdPacote);
                    if (pacote is not null)
                    {
                        pacote.Processos = await _banco.ProcessoRepository.GetProcessosPacoteAsync(pacote.IdPacote);
                        if (pacote.Processos is not null)
                            foreach (Processo processo in pacote.Processos)
                                await _banco.PacoteRepository.DeleteItemPacoteAsync(IdPacote, processo.IdProcesso);
                        await _banco.PacoteRepository.DeletePacoteAsync(pacote.IdPacote);
                        _banco.Commit();
                        return true;
                    }
                    else
                    {
                        _banco.Rollback();
                        return false;
                    }
                }
                else return false;
            }
            catch
            {
                _banco.Rollback();
                return false;
            }
        }

        public async Task<Pacote?> GetPacoteAsync(int IdPacote)
        {
            try
            {
                var retorno = await _banco.PacoteRepository.GetPacoteAsync(IdPacote);
                if (retorno is not null)
                    retorno.Processos = await _banco.ProcessoRepository.GetProcessosPacoteAsync(retorno.IdPacote);
                return retorno;
            }
            catch { return null; }
        }

        public async Task<IEnumerable<Pacote>?> GetPacotesAsync(string? DsPacote)
        {
            try
            {
                var retorno = await _banco.PacoteRepository.GetPacotesAsync(DsPacote);
                if (retorno is not null)
                    foreach(Pacote p in retorno)
                        p.Processos = await _banco.ProcessoRepository.GetProcessosPacoteAsync(p.IdPacote);
                return retorno;
            }
            catch { return null; }
        }

        public async Task<bool> InsertOrUpdatePacoteAsync(Pacote pacote)
        {
            try
            {
                if (await _banco.BeginTransactionAsync())
                {
                    await _banco.PacoteRepository.InsertOrUpdatePacoteAsync(pacote);
                    if (pacote.Processos is not null)
                        foreach (Processo processo in pacote.Processos)
                            await _banco.PacoteRepository.InsertItemPacoteAsync(pacote.IdPacote, processo.IdProcesso);
                    _banco.Commit();
                    return true;
                }
                else return false;
            }
            catch
            {
                _banco.Rollback();
                return false;
            }
        }
    }
}
