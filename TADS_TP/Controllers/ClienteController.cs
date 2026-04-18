using Microsoft.AspNetCore.Mvc;
using TADS_TP.DTOs;
using TADS_TP.Models;
using TADS_TP.Services;

namespace TADS_TP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _service.GetAll()
            .Select(c => new ClienteResponseDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                CPF = c.CPF,
                Email = c.Email
            });

            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteRequestDTO dto)
        {
            try
            {
                var cliente = new ClienteModel
                {
                    Nome = dto.Nome,
                    CPF = dto.CPF,
                    Email = dto.Email
                };

                _service.Create(cliente);

                return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClienteRequestDTO dto)
        {
            try
            {
                var cliente = new ClienteModel
                {
                    Id = id,
                    Nome = dto.Nome,
                    CPF = dto.CPF,
                    Email = dto.Email
                };

                _service.Update(id, cliente);

                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var c = _service.GetById(id);

                var dto = new ClienteResponseDTO
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    CPF = c.CPF,
                    Email = c.Email
                };

                return Ok(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
