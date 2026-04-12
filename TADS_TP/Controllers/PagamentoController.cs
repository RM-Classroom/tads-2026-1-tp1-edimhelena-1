using Microsoft.AspNetCore.Mvc;
using TADS_TP.Models;
using TADS_TP.Services;

namespace TADS_TP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : Controller
    {
        private readonly PagamentoService _service;

        public PagamentoController(PagamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] PagamentoModel pagamento)
        {
            try
            {
                _service.Create(pagamento);
                return Ok(pagamento);
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
        public IActionResult Put(int id, [FromBody] PagamentoModel pagamento)
        {
            try
            {
                _service.Update(id, pagamento);
                return Ok();
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
                _service.GetById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/aluguel/{aluguelId}")]
        public IActionResult GetByAluguel(int aluguelId)
        {
            try
            {
                var pagamentos = _service.GetByAluguel(aluguelId);
                return Ok(pagamentos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
