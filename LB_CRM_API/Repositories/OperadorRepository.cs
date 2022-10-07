using Dapper;
using Dominio;
using LB_CRM_API.Repositories.Interface;
using System.Data;
using System.Text;

namespace LB_CRM_API.Repositories
{
    public class OperadorRepository : IOperadorRepository
    {
        readonly IRepositoryBase<Operador> _repository;
        public OperadorRepository(IRepositoryBase<Operador> repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteAsync(int IdParceiro, int IdOperador)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPARCEIRO", IdParceiro);
            param.Add("@P_IDOPERADOR", IdOperador);
            return await _repository.ExecuteAsync("EXCLUI_OPERADOR",
                                                  param,
                                                  CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Operador>?> GetAllAsync(int IdParceiro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select IdParceiro, IdOperador, Login,")
                .AppendLine("Senha, NomeOperador, Email, Inativo")
                .AppendLine("from TB_Operador")
                .AppendLine("where IdParceiro = @ID");
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", IdParceiro);
            return await _repository.GetAllAsync(sql.ToString(), param);
        }

        public async Task<Operador?> GetAsync(int IdParceiro, int IdOperador)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select IdParceiro, IdOperador, Login,")
                .AppendLine("Senha, NomeOperador, Email, Inativo")
                .AppendLine("from TB_Operador")
                .AppendLine("where IdOperador = @ID_OPERADOR")
                .AppendLine("and IdParceiro = @ID_PARCEIRO");
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID_OPERADOR", IdOperador);
            param.Add("@ID_PARCEIRO", IdParceiro);
            return await _repository.GetAsync(sql.ToString(), param);
        }

        public async Task<bool> InsertOrUpdateAsync(Operador operador)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPARCEIRO", operador.IdParceiro);
            param.Add("@P_IDOPERADOR", operador.IdOperador);
            param.Add("@P_LOGIN", operador.Login);
            param.Add("@P_SENHA", operador.Senha);
            param.Add("@P_NOMEOPERADOR", operador.NomeOperador);
            param.Add("@P_EMAIL", operador.Email);
            param.Add("@P_INATIVO", operador.Inativo);
            return await _repository.ExecuteAsync("IA_OPERADOR",
                                                  param,
                                                  CommandType.StoredProcedure);
        }
    }
}
