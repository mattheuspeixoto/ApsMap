using System.Collections.Generic;
using System.Threading.Tasks;
using aps.cadastro.api.Models;

namespace aps.cadastro.api.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> ListClientes();
        Task<Cliente> ClientePorId(long id);
        Task InserirCliente(Cliente cliente);
    } 
}