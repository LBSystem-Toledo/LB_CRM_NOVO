using Dominio;
using LB_CRM_API.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class ClienteProcessoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IUnitOfCRM _query,
                                                   [FromBody] ClienteProcesso clienteProcesso)
        {
            try
            {
                return Ok(await _query.ClienteProcessoRepository.InsertOrUpdateAsync(clienteProcesso));
            }
            catch { return NotFound(); }
        }
        [HttpPost, Route("InativarClienteProcessoAsync")]
        public async Task<IActionResult> InativarClienteProcessoAsync([FromServices] IUnitOfCRM _query,
                                                                      [FromBody] ClienteProcesso clienteProcesso)
        {
            try
            {
                clienteProcesso.Inativo = true;
                return Ok(await _query.ClienteProcessoRepository.InsertOrUpdateAsync(clienteProcesso));
            }
            catch { return NotFound(); }
        }
    }
}
