using Dominio;
using LB_CRM_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class ParceiroController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] IParceiroService _banco,
                                                  [FromQuery] int IdParceiro)
        {
            try
            {
                return Ok(await _banco.GetParceiroAsync(IdParceiro));
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetParceirosAsync")]
        public async Task<IActionResult> GetParceirosAsync([FromServices] IParceiroService _banco,
                                                           [FromQuery] string? Nome)
        {
            try
            {
                return Ok(await _banco.GetParceirosAsync(Nome));
            }
            catch { return NotFound(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IParceiroService _banco,
                                                   [FromBody] Parceiro parceiro)
        {
            try
            {
                return Ok(await _banco.InsertOrUpdateParceiroAsync(parceiro));
            }
            catch { return NotFound(); }
        }
        [HttpPost, Route("InativarParceiroAsync")]
        public async Task<IActionResult> InativarParceiroAsync([FromServices] IParceiroService _banco,
                                                               [FromBody] Parceiro parceiro)
        {
            try
            {
                return Ok(await _banco.InativarParceiroAsync(parceiro));
            }
            catch { return NotFound(); }
        }
    }
}
