using Dominio;
using LB_CRM_API.Services.Interface;
using LB_CRM_API.UnitOfWork;

namespace LB_CRM_API.Services
{
    public class ParceiroService : IParceiroService
    {
        readonly IUnitOfCRM _banco;
        public ParceiroService(IUnitOfCRM banco)
        {
            _banco = banco;
        }

        public async Task<Parceiro?> GetParceiroAsync(int IdParceiro)
        {
            try
            {
                var retorno = await _banco.ParceiroRepository.GetParceiroAsync(IdParceiro);
                if (retorno is not null)
                {
                    retorno.Operadores = await _banco.OperadorRepository.GetAllAsync(retorno.IdParceiro);
                    retorno.Cidade = await _banco.CidadeRepository.GetCidadeAsync(retorno.IdCidade);
                }
                return retorno;
            }
            catch { return null; }
        }

        public async Task<IEnumerable<Parceiro>?> GetParceirosAsync(string? Nome)
        {
            try
            {
                var retorno = await _banco.ParceiroRepository.GetParceirosAsync(Nome);
                if (retorno is not null)
                    foreach (Parceiro p in retorno)
                    {
                        p.Operadores = await _banco.OperadorRepository.GetAllAsync(p.IdParceiro);
                        p.Cidade = await _banco.CidadeRepository.GetCidadeAsync(p.IdCidade);
                    }
                return retorno;
            }
            catch { return null; }
        }

        public async Task<bool> InativarParceiroAsync(Parceiro parceiro)
        {
            try
            {
                if (await _banco.BeginTransactionAsync())
                {
                    parceiro.Inativo = true;
                    await _banco.ParceiroRepository.InsertOrUpdateParceiroAsync(parceiro);
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

        public async Task<bool> InsertOrUpdateParceiroAsync(Parceiro parceiro)
        {
            try
            {
                if (await _banco.BeginTransactionAsync())
                {
                    await _banco.ParceiroRepository.InsertOrUpdateParceiroAsync(parceiro);
                    if (parceiro.Operadores is not null)
                        foreach (Operador p in parceiro.Operadores)
                        {
                            p.IdParceiro = parceiro.IdParceiro;
                            await _banco.OperadorRepository.InsertOrUpdateAsync(p);
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
    }
}
