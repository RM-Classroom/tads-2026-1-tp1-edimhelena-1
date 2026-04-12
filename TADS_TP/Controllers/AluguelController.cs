using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TADS_TP.Models;
using TADS_TP.Services;

namespace TADS_TP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AluguelController : Controller
    {
        private readonly AluguelService _service;

        public AluguelController(AluguelService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alugueis = _service.GetAll();
            return Ok(alugueis);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var aluguel = _service.GetById(id);
                return Ok(aluguel); 
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AluguelModel aluguel)
        {
            try
            {
                _service.Create(aluguel);
                return CreatedAtAction(nameof(Get), new { id = aluguel.Id }, aluguel); 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); 
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AluguelModel aluguel)
        {
            try
            {
                _service.Update(id, aluguel);
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

        [HttpGet("completo")]
        public IActionResult GetCompleto()
        {
            try
            {
                var dados = _service.GetCompleto();
                return Ok(dados);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("cliente/{clienteId}")]
        public IActionResult GetByCliente(int clienteId)
        {
            try
            {
                var alugueis = _service.GetByCliente(clienteId);
                return Ok(alugueis);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpGet("valor/{valor}")]
        public IActionResult GetByValor(decimal valor)
        {
            try
            {
                var alugueis = _service.GetByValor(valor);
                return Ok(alugueis);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
