using Microsoft.Data.SqlClient;
using System.Data;

namespace ECommerceAPI.Contexts
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SQLDefaultConnection");
        }

        public IDbConnection CreateConnection() 
            => new SqlConnection(_connectionString);
    }
}
