using Microsoft.AspNetCore.Mvc;
using TADS_TP.Models;
using TADS_TP.Services;
using TADS_TP.DTOs;

namespace TADS_TP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly PagamentoService _service;

        public PagamentoController(PagamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pagamentos = _service.GetAll()
                .Select(p => new PagamentoResponseDTO
                {
                    Id = p.Id,
                    Valor = p.Valor,
                    Status = p.Status
                });

            return Ok(pagamentos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var p = _service.GetById(id);

                var dto = new PagamentoResponseDTO
                {
                    Id = p.Id,
                    Valor = p.Valor,
                    Status = p.Status
                };

                return Ok(dto);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] PagamentoRequestDTO dto)
        {
            try
            {
                var pagamento = new PagamentoModel
                {
                    DataPagamento = dto.DataPagamento,
                    Valor = dto.Valor,
                    Status = dto.Status,
                    AluguelId = dto.AluguelId
                };

                _service.Create(pagamento);

                return CreatedAtAction(nameof(Get), new { id = pagamento.Id }, null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PagamentoRequestDTO dto)
        {
            try
            {
                var pagamento = new PagamentoModel
                {
                    Id = id,
                    DataPagamento = dto.DataPagamento,
                    Valor = dto.Valor,
                    Status = dto.Status,
                    AluguelId = dto.AluguelId
                };

                _service.Update(id, pagamento);

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

        [HttpGet("aluguel/{aluguelId}")]
        public IActionResult GetByAluguel(int aluguelId)
        {
            try
            {
                var pagamentos = _service.GetByAluguel(aluguelId)
                    .Select(p => new PagamentoResponseDTO
                    {
                        Id = p.Id,
                        Valor = p.Valor,
                        Status = p.Status
                    });

                return Ok(pagamentos);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}