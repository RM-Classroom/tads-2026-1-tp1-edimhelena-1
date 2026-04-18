using Microsoft.AspNetCore.Mvc;
using TADS_TP.DTOs;
using TADS_TP.Models;
using TADS_TP.Services;

namespace TADS_TP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FabricanteController : Controller
    {
        private readonly FabricanteService _service;

        public FabricanteController(FabricanteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var fabricantes = _service.GetAll()
                .Select(f => new FabricanteResponseDTO
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Contato = f.Contato
                });

            return Ok(fabricantes);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FabricanteRequestDTO dto)
        {
            try
            {
                var fabricante = new FabricanteModel
                {
                    Nome = dto.Nome,
                    Contato = dto.Contato
                };
                _service.Create(fabricante);
                return CreatedAtAction(nameof(Get), new { id = fabricante.Id }, fabricante);
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
        public IActionResult Put(int id, [FromBody] FabricanteRequestDTO dto)
        {
            try
            {
                var fabricante = new FabricanteModel
                {
                    Nome = dto.Nome,
                    Contato = dto.Contato
                };
                _service.Update(id, fabricante);
                return Ok(fabricante);
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
                var f = _service.GetById(id);

                var dto = new FabricanteResponseDTO
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Contato = f.Contato
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
