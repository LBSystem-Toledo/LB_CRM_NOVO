using Core.UnitOfWork;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Linq.Expressions;

namespace LB_CRM_API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        [HttpGet, Route("GetModuloAsync")]
        public async Task<IActionResult> GetAsync([FromServices] IUnitOfCRM _banco,
                                                  [FromQuery] int id_modulo)
        {
            try
            {
                var retorno = await _banco.ModuloRepositorio.GetEntityAsync(id_modulo);
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
        [HttpGet, Route("GetAllModulosAsync")]
        public async Task<IActionResult> GetAllAsync([FromServices] IUnitOfCRM _banco,
                                                     [FromQuery] string? ds_modulo)
        {
            try
            {
                Expression<Func<Modulo, bool>>? exp = null;
                if (!string.IsNullOrWhiteSpace(ds_modulo))
                    exp = x => x.Ds_modulo.Contains(ds_modulo);
                var retorno = await _banco.ModuloRepositorio.GetAllAsync(exp);
                return Ok(retorno);
            }
            catch { return NotFound(); }
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IUnitOfCRM _banco,
                                                   [FromBody] Modulo modulo)
        {
            try
            {
                await _banco.ModuloRepositorio.AdicionarAsync(modulo);
                await _banco.CommitAsync();
                return Ok();
            }
            catch { return NotFound(); }
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromServices] IUnitOfCRM _banco,
                                                  [FromBody] Modulo modulo)
        {
            try
            {
                _banco.ModuloRepositorio.Alterar(modulo);
                await _banco.CommitAsync();
                return Ok();
            }
            catch { return NotFound(); }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromServices] IUnitOfCRM _banco,
                                                     [FromQuery] int id_modulo)
        {
            try
            {
                Modulo? m = await _banco.ModuloRepositorio.GetEntityAsync(id_modulo);
                if (m is not null)
                {
                    _banco.ModuloRepositorio.Deletar(m);
                    await _banco.CommitAsync();
                    return Ok();
                }
                else return BadRequest();
            }
            catch { return NotFound(); }
        }
    }
}
