using Dominio;
using LB_CRM_API.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioClienteController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IUnitOfCRM _banco,
                                                   [FromBody] UsuarioCliente usuarioCliente)
        {
            try
            {
                return Ok(await _banco.UsuarioClienteRepository.InsertOrUpdateAsync(usuarioCliente));
            }
            catch { return NotFound(); }
        }
        [HttpPost, Route("InativarClienteProcessoAsync")]
        public async Task<IActionResult> InativarClienteProcessoAsync([FromServices] IUnitOfCRM _banco,
                                                                      [FromBody] UsuarioCliente usuarioCliente)
        {
            try
            {
                usuarioCliente.Inativo = true;
                return Ok(await _banco.UsuarioClienteRepository.InsertOrUpdateAsync(usuarioCliente));
            }
            catch { return NotFound(); }
        }
    }
}
