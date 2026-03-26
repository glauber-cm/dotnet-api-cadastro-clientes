using CadastroClientesApi.DTOs;
using CadastroClientesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientesApi.Controllers
{

    [ApiController]
    [Route("api/controller")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]       
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _service.GetByIdAsync(id);

            if(cliente == null)
                return NotFound();

            return Ok(cliente);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(ClienteCreateDto dto)
        {
            var cliente = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteCreateDto dto)
        {
            var update = await _service.UpdateAsync(id, dto);

            if(!update)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _service.DeleteAsync(id);

            if(!delete)
                return NotFound();

            return NoContent();
        }

    }
}
