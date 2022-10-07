using LB_CRM_API.Repositories.Interface;
using Dapper;
using Dominio;
using System.Text;
using System.Data;

namespace LB_CRM_API.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        readonly IRepositoryBase<Modulo> _repository;
        public ModuloRepository(IRepositoryBase<Modulo> repository) { _repository = repository; }

        public async Task<bool> DeleteModuloAsync(Modulo modulo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDMODULO", modulo.IdModulo);
            return await _repository.ExecuteAsync("EXCLUI_MODULO",
                                                  param,
                                                  CommandType.StoredProcedure);
        }

        public async Task<Modulo?> GetModuloAsync(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id);
            return await _repository.GetAsync("SELECT IDMODULO, DSMODULO FROM TB_MODULO WHERE IDMODULO = @ID", param);
        }

        public async Task<IEnumerable<Modulo>?> GetModulosAsync(string? dsmodulo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT IDMODULO, DSMODULO FROM TB_MODULO");
            if (!string.IsNullOrWhiteSpace(dsmodulo))
                sql.AppendLine("WHERE DSMODULO LIKE '%" + dsmodulo.Trim() + "%'");
            return await _repository.GetAllAsync(sql.ToString());
        }

        public async Task<bool> InsertOrUpdateModuloAsync(Modulo modulo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_IDMODULO", dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
            param.Add("@P_DSMODULO", modulo.DsModulo);
            if (await _repository.ExecuteAsync("IA_MODULO",
                                               param,
                                               CommandType.StoredProcedure))
            {
                modulo.IdModulo = param.Get<int>("@P_IDMODULO");
                return true;
            }
            else return false;


        }
    }
}
