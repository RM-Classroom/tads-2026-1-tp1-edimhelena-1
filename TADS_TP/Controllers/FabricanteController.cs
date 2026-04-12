using Microsoft.AspNetCore.Mvc;
using TADS_TP.Models;
using TADS_TP.Services;

namespace TADS_TP.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] FabricanteModel cliente)
        {
            try
            {
                _service.Create(cliente);
                return Ok(cliente);
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
        public IActionResult Put(int id, [FromBody] FabricanteModel cliente)
        {
            try
            {
                _service.Update(id, cliente);
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
    }
}
