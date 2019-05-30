using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using aps.cadastro.api.Datasource.Interfaces;

namespace aps.cadastro.api.Datasource
{
    public class ConnectionFactory : IConnection
    {
        private readonly string _connectionString;
        
        public ConnectionFactory()
        {
        }

        public ConnectionFactory(string host, string database, string user, string pass)
        {
            _connectionString = $"Server={host};Database={database};Uid={user};Pwd={pass}";
        }
        
        public IDbConnection CreateConnection(string host, string database, string user, string pass)
        {
            var connection = new MySqlConnection($"Server={host};Database={database};Uid={user};Pwd={pass}");
          
            if(connection.State == ConnectionState.Closed)
                connection.Open();
            
            return connection;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new MySqlConnection(_connectionString);
          
            if(connection.State == ConnectionState.Closed)
                connection.Open();
            
            return connection;
        }
    }
}