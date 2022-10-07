using Dapper;
using Dominio;
using LB_CRM_API.Repositories.Interface;
using System.Data;
using System.Text;

namespace LB_CRM_API.Repositories
{
    public class AtividadeRepository : IAtividadeRepository
    {
        readonly IRepositoryBase<Atividade> _repository;
        public AtividadeRepository(IRepositoryBase<Atividade> repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteAtividadeAsync(int IdAtividade)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDATIVIDADE", IdAtividade);
            return await _repository.ExecuteAsync("EXCLUI_ATIVIDADE",
                                                  param,
                                                  CommandType.StoredProcedure);
        }

        public async Task<Atividade?> GetAtividadeAsync(int IdAtividade)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", IdAtividade);
            return await _repository.GetAsync("Select IdAtividade, DsAtividade from TB_Atividade where IdAtividade = @ID", param);
        }

        public async Task<IEnumerable<Atividade>?> GetAtividadesAsync(string? DsAtividade)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select IdAtividade, DsAtividade from TB_Atividade");
            if (!string.IsNullOrWhiteSpace(DsAtividade))
                sql.AppendLine("where DsAtividade LIKE '%" + DsAtividade.Trim() + "%'");
            return await _repository.GetAllAsync(sql.ToString());
        }

        public async Task<bool> InsertOrUpdateAtividadeAsync(Atividade atividade)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDATIVIDADE", atividade.IdAtividade);
            param.Add("@P_DSATIVIDADE", atividade.DsAtividade);
            return await _repository.ExecuteAsync("IA_ATIVIDADE",
                                                  param,
                                                  CommandType.StoredProcedure);
        }
    }
}
