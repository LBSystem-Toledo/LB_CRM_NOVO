using Dapper;
using Dominio;
using LB_CRM_API.Repositories.Interface;
using System.Data;
using System.Text;

namespace LB_CRM_API.Repositories
{
    public class ParceiroRepository : IParceiroRepository
    {
        readonly IRepositoryBase<Parceiro> _repository;
        public ParceiroRepository(IRepositoryBase<Parceiro> repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteParceiroAsync(int IdParceiro)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPARCEIRO", IdParceiro);
            return await _repository.ExecuteAsync("EXCLUI_PARCEIRO",
                                                  param,
                                                  CommandType.StoredProcedure);
        }

        public async Task<Parceiro?> GetParceiroAsync(int IdParceiro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select IdParceiro, IdCidade, TpPessoa, NrDoc,")
                .AppendLine("RazaoSocial, Fantasia, Cep, Logradouro,")
                .AppendLine("Numero, Referencia, Bairro, Complemento,")
                .AppendLine("IE, Contato, Fone, Celular, Email, Franqueadora, Inativo")
                .AppendLine("from TB_Parceiro")
                .AppendLine("where IdParceiro = @ID");
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", IdParceiro);
            return await _repository.GetAsync(sql.ToString(), param);
        }

        public async Task<IEnumerable<Parceiro>?> GetParceirosAsync(string? Nome)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select IdParceiro, IdCidade, TpPessoa, NrDoc,")
                .AppendLine("RazaoSocial, Fantasia, Cep, Logradouro,")
                .AppendLine("Numero, Referencia, Bairro, Complemento,")
                .AppendLine("IE, Contato, Fone, Celular, Email, Franqueadora, Inativo")
                .AppendLine("from TB_Parceiro");
            if (!string.IsNullOrWhiteSpace(Nome))
                sql.AppendLine("where RazaoSocial like '%" + Nome.Trim() + "'% or Fantasia like '%" + Nome.Trim() + "'%");
            return await _repository.GetAllAsync(sql.ToString());
        }

        public async Task<bool> InsertOrUpdateParceiroAsync(Parceiro parceiro)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDPARCEIRO", parceiro.IdParceiro, DbType.Int32, ParameterDirection.Output);
            param.Add("@P_IDCIDADE", parceiro.IdCidade);
            param.Add("@P_TPPESSOA", parceiro.TpPessoa);
            param.Add("@P_NRDOC", parceiro.NrDoc);
            param.Add("@P_RAZAOSOCIAL", parceiro.RazaoSocial);
            param.Add("@P_FANTASIA", parceiro.Fantasia);
            param.Add("@P_CEP", parceiro.Cep);
            param.Add("@P_LOGRADOURO", parceiro.Logradouro);
            param.Add("@P_NUMERO", parceiro.Numero);
            param.Add("@P_REFERENCIA", parceiro.Referencia);
            param.Add("@P_BAIRRO", parceiro.Bairro);
            param.Add("@P_COMPLEMENTO", parceiro.Complemento);
            param.Add("@P_IE", parceiro.IE);
            param.Add("@P_CONTATO", parceiro.Contato);
            param.Add("@P_FONE", parceiro.Fone);
            param.Add("@P_CELULAR", parceiro.Celular);
            param.Add("@P_EMAIL", parceiro.Email);
            param.Add("@P_FRANQUEADORA", parceiro.Franqueadora);
            param.Add("@P_INATIVO", parceiro.Inativo);

            if (await _repository.ExecuteAsync("IA_PARCEIRO",
                                                  param,
                                                  CommandType.StoredProcedure))
            {
                parceiro.IdParceiro = param.Get<int>("@P_IDPARCEIRO");
                return true;
            }
            else return false;
        }
    }
}
