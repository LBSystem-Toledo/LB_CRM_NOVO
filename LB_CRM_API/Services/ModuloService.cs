using Dominio;
using LB_CRM_API.Services.Interface;
using LB_CRM_API.UnitOfWork;

namespace LB_CRM_API.Services
{
    public class ModuloService : IModuloService
    {
        readonly IUnitOfCRM _banco;
        public ModuloService(IUnitOfCRM banco)
        {
            _banco = banco;
        }
        public async Task<Modulo?> GetModuloAsync(int IdModulo)
        {
            try
            {
                var retorno = await _banco.ModuloRepository.GetModuloAsync(IdModulo);
                if (retorno is not null)
                    retorno.Processos = await _banco.ProcessoRepository.GetProcessosAsync(IdModulo: retorno.IdModulo);
                return retorno;
            }
            catch { return null; }
        }
        public async Task<IEnumerable<Modulo>?> GetModulosAsync(string? DsModulo)
        {
            try
            {
                var retorno = await _banco.ModuloRepository.GetModulosAsync(DsModulo);
                if (retorno is not null)
                    foreach (Modulo modulo in retorno)
                        modulo.Processos = await _banco.ProcessoRepository.GetProcessosAsync(IdModulo: modulo.IdModulo);
                return retorno;
            }
            catch { return null; }
        }
        public async Task<bool> InsertOrUpdateAsync(Modulo modulo)
        {
            try
            {
                if (await _banco.BeginTransactionAsync())
                {
                    await _banco.ModuloRepository.InsertOrUpdateModuloAsync(modulo);
                    if (modulo.Processos is not null)
                        foreach (Processo processo in modulo.Processos)
                        {
                            processo.IdModulo = modulo.IdModulo;
                            await _banco.ProcessoRepository.InsertOrUpdateProcessoAsync(processo);
                        }
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
        public async Task<bool> DeleteAsync(int IdModulo)
        {
            try
            {
                if (await _banco.BeginTransactionAsync())
                {
                    Modulo? modulo = await _banco.ModuloRepository.GetModuloAsync(IdModulo);
                    if (modulo is not null)
                    {
                        modulo.Processos = await _banco.ProcessoRepository.GetProcessosAsync(IdModulo: modulo.IdModulo);
                        if (modulo.Processos is not null)
                            foreach (Processo processo in modulo.Processos)
                                await _banco.ProcessoRepository.DeleteProcessoAsync(processo.IdProcesso);
                        await _banco.ModuloRepository.DeleteModuloAsync(modulo);
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
    }
}
