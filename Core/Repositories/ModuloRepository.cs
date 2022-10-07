using Core.Context;
using Core.Repository.Interface;
using Dapper;
using Dominio;
using System.Text;

namespace Core.Repository
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly DapperContext _context;
        public ModuloRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteModuloAsync(int id)
        {
            try
            {
                if (await _context.OpenConnectionAsync())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ID", id);

                    return await _context.Connection.ExecuteAsync("DELETE TB_MODULO WHERE ID = @ID",
                                                                  param,
                                                                  transaction: _context.Transaction,
                                                                  commandType: System.Data.CommandType.Text) > 0;
                }
                else return false;
            }
            catch { return false; }
        }

        public async Task<Modulo?> GetModuloAsync(int id)
        {
            try
            {
                if (await _context.OpenConnectionAsync())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ID", id);
                    return await _context.Connection.QueryFirstOrDefaultAsync<Modulo>(
                        "SELECT ID, DS_MODULO FROM TB_MODULO WHERE ID = @ID",
                        param,
                        transaction: _context.Transaction,
                        commandType: System.Data.CommandType.Text);
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<IEnumerable<Modulo>?> GetModulosAsync(string? ds_modulo)
        {
            try
            {
                if (await _context.OpenConnectionAsync())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT ID, DS_MODULO FROM TB_MODULO");
                    if (!string.IsNullOrWhiteSpace(ds_modulo))
                        sql.AppendLine("WHERE DS_MODULO LIKE '%" + ds_modulo.Trim() + "%'");
                    return await _context.Connection.QueryAsync<Modulo>(
                        sql.ToString(),
                        transaction: _context.Transaction,
                        commandType: System.Data.CommandType.Text);
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<bool> InsertModuloAsync(Modulo modulo)
        {
            try
            {
                if (await _context.OpenConnectionAsync())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@DS_MODULO", modulo.Ds_modulo);
                    return await _context.Connection.ExecuteAsync(
                        "INSERT INTO TB_MODULO(DS_MODULO)VALUES(@DS_MODULO)",
                        param,
                        transaction: _context.Transaction,
                        commandType: System.Data.CommandType.Text) > 0;
                }
                else return false;
            }
            catch { return false; }
        }

        public async Task<bool> UpdateModuloAsync(Modulo modulo)
        {
            try
            {
                if (await _context.OpenConnectionAsync())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ID", modulo.Id);
                    param.Add("@DS_MODULO", modulo.Ds_modulo);
                    return await _context.Connection.ExecuteAsync(
                        "UPDATE TB_MODULO SET DS_MODULO = @DS_MODULO WHERE ID = @ID",
                        param,
                        transaction: _context.Transaction,
                        commandType: System.Data.CommandType.Text) > 0;
                }
                else return false;
            }
            catch { return false; }
        }
    }
}
