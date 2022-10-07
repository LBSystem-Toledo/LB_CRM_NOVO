using LB_CRM_API.UnitOfWork;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using LB_CRM_API.Services.Interface;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        [HttpGet, Route("GetModuloAsync")]
        public async Task<IActionResult> GetAsync([FromServices] IModuloService _query,
                                                  [FromQuery] int IdModulo)
        {
            try
            {
                return Ok(await _query.GetModuloAsync(IdModulo));
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetAllModulosAsync")]
        public async Task<IActionResult> GetAllAsync([FromServices] IModuloService _query,
                                                     [FromQuery] string? DsModulo)
        {
            try
            {
                return Ok(await _query.GetModulosAsync(DsModulo));
            }
            catch { return NotFound(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IModuloService _query,
                                                   [FromBody] Modulo modulo)
        {
            try
            {
                await _query.InsertOrUpdateAsync(modulo);
                return Ok();
            }
            catch { return NotFound(); }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromServices] IModuloService _query,
                                                     [FromQuery] int IdModulo)
        {
            try
            {
                    await _query.DeleteAsync(IdModulo);
                    return Ok();
            }
            catch { return NotFound(); }
        }
    }
}
