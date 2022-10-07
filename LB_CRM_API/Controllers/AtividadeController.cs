using Dominio;
using LB_CRM_API.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        [HttpGet, Route("GetAtividadeAsync")]
        public async Task<IActionResult> GetAsync([FromServices] IUnitOfCRM _query,
                                                  [FromQuery] int IdAtividade)
        {
            try
            {
                return Ok(await _query.AtividadeRepository.GetAtividadeAsync(IdAtividade));
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetAtividadesAsync")]
        public async Task<IActionResult> GetAllAsync([FromServices] IUnitOfCRM _query,
                                                     [FromQuery] string? DsAtividade)
        {
            try
            {
                return Ok(await _query.AtividadeRepository.GetAtividadesAsync(DsAtividade));
            }
            catch { return NotFound(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IUnitOfCRM _query,
                                                   [FromBody] Atividade atividade)
        {
            try
            {
                await _query.AtividadeRepository.InsertOrUpdateAtividadeAsync(atividade);
                return Ok();
            }
            catch { return NotFound(); }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromServices] IUnitOfCRM _query,
                                                     [FromQuery] int IdAtividade)
        {
            try
            {
                await _query.AtividadeRepository.DeleteAtividadeAsync(IdAtividade);
                return Ok();
            }
            catch { return NotFound(); }
        }
    }
}
