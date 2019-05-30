using System.Collections.Generic;
using System.Threading.Tasks;
using aps.cadastro.api.Models;
using aps.cadastro.api.Repositories.Interfaces;
using aps.cadastro.api.Services.Interfaces;

namespace aps.cadastro.api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository repository)
        {
            _clienteRepository = repository;
        }

        public async Task<List<Cliente>> ListClientes()
        {
            return await _clienteRepository.ListClientes();
        }

        public async Task<Cliente> ClientePorId(long id)
        {
            return await _clienteRepository.ClientePorId(id);
        }

        public async Task InserirCliente(Cliente cliente)
        {
           await _clienteRepository.InserirCliente(cliente);
        }

    }
}