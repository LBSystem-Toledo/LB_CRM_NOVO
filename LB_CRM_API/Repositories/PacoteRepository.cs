using Dapper;
using Dominio;
using LB_CRM_API.Repositories.Interface;
using System.Data;
using System.Text;

namespace LB_CRM_API.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        readonly IRepositoryBase<Pacote> _repository;
        public PacoteRepository(IRepositoryBase<Pacote> repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeletePacoteAsync(int IdPacote)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPACOTE", IdPacote);
            return await _repository.ExecuteAsync("EXCLUI_PACOTE",
                                                  param,
                                                  CommandType.StoredProcedure);
        }

        public async Task<Pacote?> GetPacoteAsync(int IdPacote)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", IdPacote);
            return await _repository.GetAsync("Select IdPacote, DsPacote from TB_Pacote where IdPacote = @ID", param);
        }

        public async Task<IEnumerable<Pacote>?> GetPacotesAsync(string? DsPacote)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select IdPacote, DsPacote from TB_Pacote");
            if (!string.IsNullOrWhiteSpace(DsPacote))
                sql.AppendLine("where DsPacote LIKE '%" + DsPacote.Trim() + "%'");
            return await _repository.GetAllAsync(sql.ToString());
        }

        public async Task<bool> InsertOrUpdatePacoteAsync(Pacote pacote)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPACOTE", pacote.IdPacote, DbType.Int32, ParameterDirection.InputOutput);
            param.Add("@P_DSPACOTE", pacote.DsPacote);
            if (await _repository.ExecuteAsync("IA_PACOTE",
                                               param,
                                               CommandType.StoredProcedure))
            {
                pacote.IdPacote = param.Get<int>("@P_IDPACOTE");
                return true;
            }
            else return false;
        }

        public async Task<bool> InsertItemPacoteAsync(int IdPacote, int IdProcesso)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPACOTE", IdPacote);
            param.Add("@P_IDPROCESSO", IdProcesso);
            return await _repository.ExecuteAsync("IA_ITEMPACOTE",
                                                  param,
                                                  CommandType.StoredProcedure);
        }

        public async Task<bool> DeleteItemPacoteAsync(int IdPacote, int IdProcesso)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPACOTE", IdPacote);
            param.Add("@P_IDPROCESSO", IdProcesso);
            return await _repository.ExecuteAsync("EXCLUI_ITEMPACOTE",
                                                  param,
                                                  CommandType.StoredProcedure);
        }
    }
}
