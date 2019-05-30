using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aps.cadastro.api.Datasource.Interfaces;
using aps.cadastro.api.Models;
using aps.cadastro.api.Repositories.Interfaces;

using Dapper;

namespace aps.cadastro.api.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConnection _connectionFactory; 
            
        public ClienteRepository(IConnection factory)
        {
            _connectionFactory = factory;
        }
        
        public async Task<List<Cliente>> ListClientes()
        {
            using (var conn = _connectionFactory.CreateConnection())
            {
                var result = await conn.QueryAsync<Cliente>(@"SELECT Id, Nome, Cpf, Email FROM Cliente");
                return result.ToList();
            }
        }

        public async Task<Cliente> ClientePorId(long id)
        {
            using (var conn = _connectionFactory.CreateConnection())
            {

                var result = await conn.QueryAsync<Cliente>(@"SELECT Id, Nome, Cpf, Email FROM Cliente Where Id = @Id", new { id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task InserirCliente(Cliente cliente)
        {
            using (var conn = _connectionFactory.CreateConnection())
            {
                await conn.QueryAsync<Cliente>("INSERT INTO Cliente(Nome, Cpf, Email) values(@Nome, @Cpf, @Email)", new { Nome = cliente.Nome, Cpf = cliente.Cpf, Email = cliente.Email });
                
            }
        }

    }
}