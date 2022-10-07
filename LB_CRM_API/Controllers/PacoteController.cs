using Dominio;
using LB_CRM_API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class PacoteController : ControllerBase
    {
        [HttpGet, Route("GetPacoteAsync")]
        public async Task<IActionResult> GetAsync([FromServices] IPacoteService _query,
                                                  [FromQuery] int IdPacote)
        {
            try
            {
                return Ok(await _query.GetPacoteAsync(IdPacote));
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetPacotesAsync")]
        public async Task<IActionResult> GetAllAsync([FromServices] IPacoteService _query,
                                                     [FromQuery] string? DsPacote)
        {
            try
            {
                return Ok(await _query.GetPacotesAsync(DsPacote));
            }
            catch { return NotFound(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IPacoteService _query,
                                                   [FromBody] Pacote pacote)
        {
            try
            {
                return Ok(await _query.InsertOrUpdatePacoteAsync(pacote));
            }
            catch { return NotFound(); }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromServices] IPacoteService _query,
                                                     [FromQuery] int IdPacote)
        {
            try
            {
                return Ok(await _query.DeletePacoteAsync(IdPacote));
            }
            catch { return NotFound(); }
        }
    }
}
