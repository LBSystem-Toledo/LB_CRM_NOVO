using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LB_CRM_API.Context
{
    public sealed class DapperContext: IDisposable
    {
        public SqlConnection? Connection { get; private set; }
        public SqlTransaction? Transaction { get; set; }

        public DapperContext(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("comCRM"));
        }

        public async Task<bool> OpenConnectionAsync()
        {
            try
            {
                if (Connection is not null)
                {
                    if (Connection.State == ConnectionState.Open)
                        return true;
                    {
                        await Connection.OpenAsync();
                        return true;
                    }
                }
                else return false;
            }
            catch { return false; }
        }

        public void Dispose()=> Connection?.Dispose();
    }
}
