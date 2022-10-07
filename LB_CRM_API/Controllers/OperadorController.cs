using Dominio;
using LB_CRM_API.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IUnitOfCRM _query,
                                                   [FromBody] Operador operador)
        {
            try
            {
                return Ok(await _query.OperadorRepository.InsertOrUpdateAsync(operador));
            }
            catch { return NotFound(); }
        }
        [HttpPost, Route("InativarOperadorAsync")]
        public async Task<IActionResult> InativarOperadorAsync([FromServices] IUnitOfCRM _query,
                                                               [FromBody] Operador operador)
        {
            try
            {
                operador.Inativo = true;
                return Ok(await _query.OperadorRepository.InsertOrUpdateAsync(operador));
            }
            catch { return NotFound(); }
        }
    }
}
