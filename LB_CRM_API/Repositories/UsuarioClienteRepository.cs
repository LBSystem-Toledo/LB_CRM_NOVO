using Dapper;
using Dominio;
using LB_CRM_API.Repositories.Interface;
using System.Data;
using System.Text;

namespace LB_CRM_API.Repositories
{
    public class UsuarioClienteRepository : IUsuarioClienteRepository
    {
        readonly IRepositoryBase<UsuarioCliente> _repository;
        public UsuarioClienteRepository(IRepositoryBase<UsuarioCliente> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioCliente>?> GetAllAsync(int? IdCliente)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select IdCliente, IdLogin, Login,")
                .AppendLine("Senha, NomeUsuario, Email,")
                .AppendLine("NotificaEvolucao, Inativo")
                .AppendLine("from TB_UsuarioCliente");
            if (IdCliente.HasValue)
                sql.AppendLine("where IdCliente = " + IdCliente.Value);
            return await _repository.GetAllAsync(sql.ToString());
        }

        public async Task<bool> InsertOrUpdateAsync(UsuarioCliente usuario)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDCLIENTE", usuario.IdCliente);
            param.Add("@P_IDLOGIN", usuario.IdLogin);
            param.Add("@P_LOGIN", usuario.Login);
            param.Add("@P_SENHA", usuario.Senha);
            param.Add("@P_NOMEUSUARIO", usuario.NomeUsuario);
            param.Add("@P_EMAIL", usuario.Email);
            param.Add("@P_NOTIFICAEVOLUCAO", usuario.NotificaEvolucao);
            param.Add("@P_INATIVO", usuario.Inativo);
            return await _repository.ExecuteAsync("IA_USUARIOCLIENTE",
                                                  param,
                                                  CommandType.StoredProcedure);

        }
    }
}
