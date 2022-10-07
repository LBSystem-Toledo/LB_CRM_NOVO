using Dapper;
using Dominio;
using LB_CRM_API.Repositories.Interface;
using System.Data;
using System.Text;

namespace LB_CRM_API.Repositories
{
    public class ClienteProcessoRepository : IClienteProcessoRepository
    {
        readonly IRepositoryBase<ClienteProcesso> _repository;
        public ClienteProcessoRepository(IRepositoryBase<ClienteProcesso> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteProcesso>?> GetAllAsync(int IdCliente)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select IdCliente, IdProcesso,")
                .AppendLine("DtIni, DtFin, MotivoInativo, Inativo")
                .AppendLine("from TB_ClienteProcesso")
                .AppendLine("where IdCliente = " + IdCliente);
            return await _repository.GetAllAsync(sql.ToString());
        }

        public async Task<bool> InsertOrUpdateAsync(ClienteProcesso clienteProcessos)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDCLIENTE", clienteProcessos.IdCliente);
            param.Add("@P_IDPROCESSO", clienteProcessos.IdProcesso);
            param.Add("@P_DTINI", clienteProcessos.DtIni);
            param.Add("@P_DTFIN", clienteProcessos.DtFin);
            param.Add("@P_MOTIVOINATIVO", clienteProcessos.MotivoInativo);
            param.Add("@P_INATIVO", clienteProcessos.Inativo);
            return await _repository.ExecuteAsync("IA_CLIENTEPROCESSO", param, CommandType.StoredProcedure);
        }
    }
}
