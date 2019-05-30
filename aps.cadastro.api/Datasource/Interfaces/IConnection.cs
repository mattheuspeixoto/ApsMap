using System.Data;
using System.Threading.Tasks;

namespace aps.cadastro.api.Datasource.Interfaces
{
    public interface IConnection
    {
        IDbConnection CreateConnection(string host, string database, string user, string pass);
        IDbConnection CreateConnection();
    }
}