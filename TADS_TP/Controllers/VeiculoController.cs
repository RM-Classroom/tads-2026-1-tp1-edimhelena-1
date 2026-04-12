using Microsoft.AspNetCore.Mvc;
using TADS_TP.DTOs;
using TADS_TP.Models;
using TADS_TP.Services;

namespace TADS_TP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : Controller
    {
        private readonly VeiculoService _service;
        public VeiculoController(VeiculoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var veiculos = _service.GetAll()
            .Select(v => new VeiculoResponseDTO
            {
                Id = v.Id,
                Modelo = v.Modelo,
                Ano = v.Ano,
                Quilometragem = v.Quilometragem
            });

            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var veiculo = _service.GetById(id);

                var dto = new VeiculoResponseDTO
                {
                    Id = veiculo.Id,
                    Modelo = veiculo.Modelo,
                    Ano = veiculo.Ano,
                    Quilometragem = veiculo.Quilometragem,
                    FabricanteId = veiculo.FabricanteId
                };

                return Ok(dto); 
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] VeiculoRequestDTO dto)
        {
            try
            {
                var veiculo = new VeiculoModel
                {
                    Modelo = dto.Modelo,
                    Ano = dto.Ano,
                    Quilometragem = dto.Quilometragem,
                    FabricanteId = dto.FabricanteId
                };

                _service.Create(veiculo);
                return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VeiculoRequestDTO dto)
        {
            try
            {
                var veiculo = new VeiculoModel
                {
                    Id = id,
                    Modelo = dto.Modelo,
                    Ano = dto.Ano,
                    Quilometragem = dto.Quilometragem,
                    FabricanteId = dto.FabricanteId
                };

                _service.Update(id, veiculo);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
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
                return NotFound(e.Message);
            }
        }

        [HttpGet("fabricante/{nomeFabricante}")]
        public IActionResult GetByFabricante(string nomeFabricante)
        {
            try
            {
                var veiculos = _service.GetByFabricante(nomeFabricante)
                    .Select(c => new VeiculoResponseDTO
                    {
                        Id = c.Id,
                        Modelo = c.Modelo,
                        Ano = c.Ano,
                        Quilometragem = c.Quilometragem,
                        FabricanteId = c.FabricanteId
                    }); ;
                return Ok(veiculos);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
