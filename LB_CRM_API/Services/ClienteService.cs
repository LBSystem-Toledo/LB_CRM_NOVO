using Dominio;
using LB_CRM_API.Repositories.Interface;
using LB_CRM_API.Services.Interface;
using LB_CRM_API.UnitOfWork;

namespace LB_CRM_API.Services
{
    public class ClienteService : IClienteService
    {
        readonly IUnitOfCRM _banco;
        public ClienteService(IUnitOfCRM banco)
        {
            _banco = banco;
        }

        public async Task<Cliente?> GetClienteAsync(int IdCliente)
        {
            try
            {
                var retorno = await _banco.ClienteRepository.GetAsync(IdCliente);
                if (retorno is not null)
                {
                    retorno.Processos = await _banco.ClienteProcessoRepository.GetAllAsync(IdCliente);
                    retorno.Usuarios = await _banco.UsuarioClienteRepository.GetAllAsync(IdCliente);
                }
                return retorno;
            }
            catch { return null; }
        }

        public async Task<IEnumerable<Cliente>?> GetClientesAsync(string? Nome, int? IdAtividade, int? IdParceiro)
        {
            try
            {
                var retorno = await _banco.ClienteRepository.GetAllAsync(Nome, IdAtividade, IdParceiro);
                if (retorno is not null)
                    foreach (Cliente c in retorno)
                    {
                        c.Processos = await _banco.ClienteProcessoRepository.GetAllAsync(c.IdCliente);
                        c.Usuarios = await _banco.UsuarioClienteRepository.GetAllAsync(c.IdCliente);
                    }
                return retorno;
            }
            catch { return null; }
        }

        public async Task<bool> InsertOrUpdateAsync(Cliente cliente)
        {
            try
            {
                if (await _banco.BeginTransactionAsync())
                {
                    await _banco.ClienteRepository.InsertOrUpdateAsync(cliente);
                    if (cliente.Processos is not null)
                        foreach (ClienteProcesso processo in cliente.Processos)
                        {
                            processo.IdCliente = cliente.IdCliente;
                            await _banco.ClienteProcessoRepository.InsertOrUpdateAsync(processo);
                        }
                    if(cliente.Usuarios is not null)
                        foreach(UsuarioCliente usuarioCliente in cliente.Usuarios)
                        {
                            usuarioCliente.IdCliente = cliente.IdCliente;
                            await _banco.UsuarioClienteRepository.InsertOrUpdateAsync(usuarioCliente);
                        }
                    _banco.Commit();
                    return true;
                }
                else return false;
            }
            catch
            {
                _banco.Rollback();
                return false;
            }
        }

        public async Task<bool> InativarClienteAsync(Cliente cliente)
        {
            try
            {
                if (await _banco.BeginTransactionAsync())
                {
                    cliente.Inativo = true;
                    await _banco.ClienteRepository.InsertOrUpdateAsync(cliente);
                    _banco.Commit();
                    return true;
                }
                else return false;
            }
            catch
            {
                _banco.Rollback();
                return false;
            }
        }
    }
}
