using Dapper;
using Dominio;
using LB_CRM_API.Repositories.Interface;
using System.Data;
using System.Text;

namespace LB_CRM_API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        readonly IRepositoryBase<Cliente> _repository;
        public ClienteRepository(IRepositoryBase<Cliente> repository) { _repository = repository; }

        public async Task<bool> DeleteAsync(int IdCliente)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDCLIENTE", IdCliente);
            return await _repository.ExecuteAsync("EXCLUI_CLIENTE",
                                                  param,
                                                  CommandType.StoredProcedure);
        }

        public Task<IEnumerable<Cliente>?> GetAllAsync(string? Nome, int? IdAtividade, int? IdParceiro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select IdCliente, IdCidade, IdAtividade,")
                .AppendLine("IdParceiro, IdPacote, TpPessoa, NrDoc,")
                .AppendLine("Razaosocial, fantasia, cep, logradouro,")
                .AppendLine("numero, referencia, bairro, complemento,")
                .AppendLine("ie, contato, fone, celular, email, obs,")
                .AppendLine("nrseqlic, dtlicenca, mobile, qtmobile, inativo")
                .AppendLine("from TB_Cliente");
            string cond = "where";
            if(!string.IsNullOrWhiteSpace(Nome))
            {
                sql.AppendLine(cond + " (RazaoSocial like '%" + Nome.Trim() + "'% or Fantasia like '%" + Nome.Trim() + "'%)");
                cond = "and";
            }
            if(IdAtividade.HasValue)
            {
                sql.AppendLine(cond + " IdAtividade = " + IdAtividade.Value);
                cond = "and";
            }
            if (IdParceiro.HasValue)
                sql.AppendLine(cond + " IdParceiro = " + IdParceiro.Value);
            return _repository.GetAllAsync(sql.ToString());
        }

        public async Task<Cliente?> GetAsync(int IdCliente)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select IdCliente, IdCidade, IdAtividade,")
                .AppendLine("IdParceiro, IdPacote, TpPessoa, NrDoc,")
                .AppendLine("Razaosocial, fantasia, cep, logradouro,")
                .AppendLine("numero, referencia, bairro, complemento,")
                .AppendLine("ie, contato, fone, celular, email, obs,")
                .AppendLine("nrseqlic, dtlicenca, mobile, qtmobile, inativo")
                .AppendLine("from TB_Cliente")
                .AppendLine("where IdCliente = @ID");
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", IdCliente);
            return await _repository.GetAsync(sql.ToString(), param);
        }

        public async Task<bool> InsertOrUpdateAsync(Cliente cliente)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDCLIENTE", cliente.IdCliente, DbType.Int32, ParameterDirection.Output);
            param.Add("@P_IDCIDADE", cliente.IdCidade);
            param.Add("@P_IDATIVIDADE", cliente.IdAtividade);
            param.Add("@P_IDPARCEIRO", cliente.IdParceiro);
            param.Add("@P_IDPACOTE", cliente.IdParceiro);
            param.Add("@P_TPPESSOA", cliente.TpPessoa);
            param.Add("@P_NRDOC", cliente.NrDoc);
            param.Add("@P_RAZAOSOCIAL", cliente.RazaoSocial);
            param.Add("@P_FANTASIA", cliente.Fantasia);
            param.Add("@P_CEP", cliente.Cep);
            param.Add("@P_LOGRADOURO", cliente.Logradouro);
            param.Add("@P_NUMERO", cliente.Numero);
            param.Add("@P_REFERENCIA", cliente.Referencia);
            param.Add("@P_BAIRRO", cliente.Bairro);
            param.Add("@P_COMPLEMENTO", cliente.Complemento);
            param.Add("@P_IE", cliente.IE);
            param.Add("@P_CONTATO", cliente.Contato);
            param.Add("@P_FONE", cliente.Fone);
            param.Add("@P_CELULAR", cliente.Celular);
            param.Add("@P_EMAIL", cliente.Email);
            param.Add("@P_OBS", cliente.Obs);
            param.Add("@P_NRSEQLIC", cliente.NrSeqLic);
            param.Add("@P_DTLICENCA", cliente.DtLicenca);
            param.Add("@P_MOBILE", cliente.Mobile);
            param.Add("@P_QTMOBILE", cliente.QtMobile);
            param.Add("@P_INATIVO", cliente.Inativo);
            if (await _repository.ExecuteAsync("IA_CLIENTE",
                                               param,
                                               CommandType.StoredProcedure))
            {
                cliente.IdCliente = param.Get<int>("@P_IDCLIENTE");
                return true;
            }
            else return false;
        }
    }
}
