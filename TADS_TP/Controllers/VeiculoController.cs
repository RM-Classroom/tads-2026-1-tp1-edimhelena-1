using Microsoft.AspNetCore.Mvc;
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
            var veiculos = _service.GetAll();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var veiculo = _service.GetById(id);
                return Ok(veiculo); 
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] VeiculoModel veiculo)
        {
            try
            {
                _service.Create(veiculo);
                return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VeiculoModel veiculo)
        {
            try
            {
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
                var veiculos = _service.GetByFabricante(nomeFabricante);
                return Ok(veiculos);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
