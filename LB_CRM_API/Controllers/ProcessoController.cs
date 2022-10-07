using Dominio;
using LB_CRM_API.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        [HttpGet, Route("GetProcessoAsync")]
        public async Task<IActionResult> GetAsync([FromServices] IUnitOfCRM _banco,
                                                  [FromQuery] int id_processo)
        {
            try
            {
                var retorno = await _banco.ProcessoRepository.GetProcessoAsync(id_processo);
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetAllProcessosAsync")]
        public async Task<IActionResult> GetAllAsync([FromServices] IUnitOfCRM _banco,
                                                     [FromQuery] string? ds_processo,
                                                     [FromQuery] string? complemento,
                                                     [FromQuery] int? moduloid)
        {
            try
            {
                var retorno = await _banco.ProcessoRepository.GetProcessosAsync(ds_processo, complemento, moduloid);
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IUnitOfCRM _banco,
                                                   [FromBody] Processo processo)
        {
            try
            {
                await _banco.ProcessoRepository.InsertOrUpdateProcessoAsync(processo);
                _banco.Commit();
                return Ok();
            }
            catch { return NotFound(); }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromServices] IUnitOfCRM _banco,
                                                     [FromQuery] int id_processo)
        {
            try
            {
                await _banco.ProcessoRepository.DeleteProcessoAsync(id_processo);
                _banco.Commit();
                return Ok();
            }
            catch { return NotFound(); }
        }
    }
}
