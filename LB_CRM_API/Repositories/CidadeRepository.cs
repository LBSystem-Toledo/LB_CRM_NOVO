using Dapper;
using Dominio;
using LB_CRM_API.Repositories.Interface;
using System.Data;
using System.Text;

namespace LB_CRM_API.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        readonly IRepositoryBase<Cidade> _repository;
        public CidadeRepository(IRepositoryBase<Cidade> repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteCidadeAsync(int IdCidade)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDCIDADE", IdCidade);
            return await _repository.ExecuteAsync("EXCLUI_CIDADE",
                                                  param,
                                                  CommandType.StoredProcedure);
        }

        public async Task<Cidade?> GetCidadeAsync(int IdCidade)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", IdCidade);
            return await _repository.GetAsync("Select IdCidade, DsCidade, UF from TB_Cidade where IdCidade = @ID", param);
        }

        public async Task<IEnumerable<Cidade>?> GetCidadesAsync(string? DsCidade, string? Uf)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select IdCidade, DsCidade, UF from TB_Cidade");
            string cond = "WHERE";
            if (!string.IsNullOrWhiteSpace(DsCidade))
            {
                sql.AppendLine(cond + " DsCidade LIKE '%" + DsCidade.Trim() + "%'");
                cond = "AND";
            }
            if (!string.IsNullOrWhiteSpace(Uf))
                sql.AppendLine(cond + " UF = '" + Uf.Trim() + "'");
            return await _repository.GetAllAsync(sql.ToString());
        }

        public async Task<bool> InsertOrUpdateCidadeAsync(Cidade cidade)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDCIDADE", cidade.IdCidade);
            param.Add("@P_DSCIDADE", cidade.DsCidade);
            param.Add("@P_UF", cidade.Uf);
            return await _repository.ExecuteAsync("IA_CIDADE",
                                                  param,
                                                  CommandType.StoredProcedure);
        }
    }
}
