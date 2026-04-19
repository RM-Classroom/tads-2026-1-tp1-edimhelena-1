using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TADS_TP.DTOs;
using TADS_TP.Models;
using TADS_TP.Services;

namespace TADS_TP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        private readonly AluguelService _service;

        public AluguelController(AluguelService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alugueis = _service.GetAll()
               .Select(a => new AluguelResponseDTO
               {
                   Id = a.Id,
                   DataInicio = a.DataInicio,
                   DataFim = a.DataFim,
                   ValorTotal = a.ValorTotal
               });

            return Ok(alugueis);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var a = _service.GetById(id);

                var dto = new AluguelResponseDTO
                {
                    Id = a.Id,
                    DataInicio = a.DataInicio,
                    DataFim = a.DataFim,
                    ValorTotal = a.ValorTotal
                };

                return Ok(dto);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AluguelRequestDTO dto)
        {
            try
            {
                var aluguel = new AluguelModel
                {
                    DataInicio = dto.DataInicio,
                    DataFim = dto.DataFim,
                    QuilometragemInicial = dto.QuilometragemInicial,
                    ValorDiaria = dto.ValorDiaria,
                    VeiculoId = dto.VeiculoId,
                    ClienteId = dto.ClienteId
                };

                _service.Create(aluguel);

                return CreatedAtAction(nameof(Get), new { id = aluguel.Id }, aluguel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); 
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AluguelUpdateDTO dto)
        {
            try
            {
                var aluguel = new AluguelModel
                {
                    Id = id,
                    DataInicio = dto.DataInicio,
                    DataFim = dto.DataFim,
                    QuilometragemInicial = dto.QuilometragemInicial,
                    QuilometragemFinal = dto.QuilometragemFinal,
                    ValorDiaria = dto.ValorDiaria,
                    DataDevolucao = dto.DataDevolucao
                };

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
                var dados = _service.GetCompleto()
                    .Select(a => new AluguelResponseDTO
                    {
                        Id = a.Id,
                        DataInicio = a.DataInicio,
                        DataFim = a.DataFim,
                        ValorTotal = a.ValorTotal,
                        ClienteNome = a.Cliente.Nome,
                        VeiculoModelo = a.Veiculo.Modelo
                    });

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
                var alugueis = _service.GetByCliente(clienteId)
                    .Select(a => new AluguelResponseDTO
                    {
                        Id = a.Id,
                        DataInicio = a.DataInicio,
                        DataFim = a.DataFim,
                        ValorTotal = a.ValorTotal
                    });

                return Ok(alugueis);
            } 
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpGet("valor/{valor}")]
        public IActionResult GetByValor(double valor)
        {
            try
            {
                var alugueis = _service.GetByValor(valor)
                    .Select(a => new AluguelResponseDTO
                    {
                        Id = a.Id,
                        DataInicio = a.DataInicio,
                        DataFim = a.DataFim,
                        ValorTotal = a.ValorTotal
                    });

                return Ok(alugueis);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
