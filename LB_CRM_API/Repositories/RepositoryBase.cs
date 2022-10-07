using Dapper;
using Dominio;
using LB_CRM_API.Context;
using LB_CRM_API.Repositories.Interface;
using System.Data;

namespace LB_CRM_API.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        readonly DapperContext _context;
        public RepositoryBase(DapperContext context) { _context = context; }

        public async Task<IEnumerable<T>?> GetAllAsync(string sql, object? param = null)
        {
            try
            {
                if (await _context.OpenConnectionAsync())
                {
                    return await _context.Connection.QueryAsync<T>(sql,
                                                                   param: param,
                                                                   transaction: _context.Transaction,
                                                                   commandType: System.Data.CommandType.Text);
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<T?> GetAsync(string sql, object? param = null)
        {
            try
            {
                if (await _context.OpenConnectionAsync())
                {
                    return await _context.Connection.QueryFirstOrDefaultAsync<T>(sql,
                                                                                 param: param,
                                                                                 transaction: _context.Transaction,
                                                                                 commandType: System.Data.CommandType.Text);
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<bool> ExecuteAsync(string comando, object param, CommandType commandType)
        {
            try
            {
                if (await _context.OpenConnectionAsync())
                {
                    return await _context.Connection.ExecuteAsync(comando,
                                                                  param: param,
                                                                  transaction: _context.Transaction,
                                                                  commandType: commandType) > 0;
                }
                else return false;
            }
            catch { return false; }
        }

    }
}
