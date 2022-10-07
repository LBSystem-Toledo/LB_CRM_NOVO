using Dominio;
using LB_CRM_API.Repositories.Interface;
using LB_CRM_API.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        [HttpGet, Route("GetCidadeAsync")]
        public async Task<IActionResult> GetAsync([FromServices] IUnitOfCRM _query,
                                                  [FromQuery] int IdCidade)
        {
            try
            {
                return Ok(await _query.CidadeRepository.GetCidadeAsync(IdCidade));
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetCidadesAsync")]
        public async Task<IActionResult> GetAllAsync([FromServices] IUnitOfCRM _query,
                                                     [FromQuery] string? DsCidade,
                                                     [FromQuery] string? Uf)
        {
            try
            {
                return Ok(await _query.CidadeRepository.GetCidadesAsync(DsCidade, Uf));
            }
            catch { return NotFound(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IUnitOfCRM _query,
                                                   [FromBody] Cidade cidade)
        {
            try
            {
                return Ok(await _query.CidadeRepository.InsertOrUpdateCidadeAsync(cidade));
            }
            catch { return NotFound(); }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromServices] IUnitOfCRM _query,
                                                     [FromQuery] int IdCidade)
        {
            try
            {
                return Ok(await _query.CidadeRepository.DeleteCidadeAsync(IdCidade));
            }
            catch { return NotFound(); }
        }
    }
}
