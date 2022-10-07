using Dominio;
using LB_CRM_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet, Route("GetClienteAsync")]
        public async Task<IActionResult> GetAsync([FromServices] IClienteService _query,
                                                  [FromQuery] int IdCliente)
        {
            try
            {
                return Ok(await _query.GetClienteAsync(IdCliente));
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetClientesAsync")]
        public async Task<IActionResult> GetAllAsync([FromServices] IClienteService _query,
                                                     [FromQuery] string? Nome, 
                                                     [FromQuery] int? IdAtividade, 
                                                     [FromQuery] int? IdParceiro)
        {
            try
            {
                return Ok(await _query.GetClientesAsync(Nome, IdAtividade, IdParceiro));
            }
            catch { return NotFound(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IClienteService _query,
                                                   [FromBody] Cliente cliente)
        {
            try
            {
                return Ok(await _query.InsertOrUpdateAsync(cliente));
            }
            catch { return NotFound(); }
        }
        [HttpPost, Route("InativarClienteAsync")]
        public async Task<IActionResult> InativarClienteAsync([FromServices] IClienteService _query,
                                                              [FromBody] Cliente cliente)
        {
            try
            {
                return Ok(await _query.InativarClienteAsync(cliente));
            }
            catch { return NotFound(); }
        }
    }
}
