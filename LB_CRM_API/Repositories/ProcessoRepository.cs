using Dapper;
using Dominio;
using LB_CRM_API.Repositories.Interface;
using System.Data;
using System.Text;

namespace LB_CRM_API.Repositories
{
    public class ProcessoRepository : IProcessoRepository
    {
        readonly RepositoryBase<Processo> _repository;
        public ProcessoRepository(RepositoryBase<Processo> repository) { _repository = repository; }

        public async Task<bool> DeleteProcessoAsync(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPROCESSO", id);
            return await _repository.ExecuteAsync("EXCLUI_PROCESSO",
                                                  param,
                                                  CommandType.StoredProcedure);
        }

        public async Task<Processo?> GetProcessoAsync(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id);
            return await _repository.GetAsync("Select IdProcesso, IdModulo, DsProcesso, Complemento from TB_Processo where IdProcesso = @ID", param);
        }

        public async Task<IEnumerable<Processo>?> GetProcessosAsync(string? dsprocesso = null,
                                                                    string? complemento = null,
                                                                    int? IdModulo = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select IdProcesso, IdModulo, DsProcesso, Complemento from TB_Processo");
            string cond = "WHERE";
            if (!string.IsNullOrWhiteSpace(dsprocesso))
            {
                sql.AppendLine(cond + " DsProcesso LIKE '%" + dsprocesso.Trim() + "%'");
                cond = "AND";
            }
            if (!string.IsNullOrWhiteSpace(complemento))
            {
                sql.AppendLine(cond + " Complemento LIKE '%" + complemento.Trim() + "%'");
                cond = "AND";
            }
            if (IdModulo.HasValue)
                sql.AppendLine(cond + " IdModulo = " + IdModulo.Value);
            return await _repository.GetAllAsync(sql.ToString());
        }

        public async Task<IEnumerable<Processo>?> GetProcessosPacoteAsync(int IdPacote)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.IdProcesso, a.IdModulo, a.DsProcesso, a.Complemento")
                .AppendLine("from TB_Processo a")
                .AppendLine("inner join TB_ItemPacote b")
                .AppendLine("on a.IdProcesso = b.IdProcesso")
                .AppendLine("where b.IdPacote = " + IdPacote);
            return await _repository.GetAllAsync(sql.ToString());
        }

        public async Task<bool> InsertOrUpdateProcessoAsync(Processo processo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPROCESSO", processo.IdProcesso);
            param.Add("@P_IDMODULO", processo.IdModulo);
            param.Add("@P_DSPROCESSO", processo.DsProcesso);
            param.Add("@P_COMPLEMENTO", processo.Complemento);
            return await _repository.ExecuteAsync("IA_PROCESSO",
                                                  param,
                                                  CommandType.StoredProcedure);
        }
    }
}
