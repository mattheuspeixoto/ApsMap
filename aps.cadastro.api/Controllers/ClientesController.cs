using System;
using System.Threading.Tasks;
using aps.cadastro.api.Models;
using aps.cadastro.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace aps.cadastro.api.Controllers
{
    //localhost:80/api/clientes

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService service)
        {
            _clienteService = service;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //TODO implementação
                var result = await _clienteService.ListClientes();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.GetBaseException());
            }
        }

        // GET
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                //TODO implementação
                var result = await _clienteService.ClientePorId(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.GetBaseException());
            }
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                //TODO implementação
                await _clienteService.InserirCliente(cliente);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.GetBaseException());
            }
        }

    }
}