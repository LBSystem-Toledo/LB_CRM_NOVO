using Core.Repository.Interface;
using Dominio;

namespace Core.UnitOfWork
{
    public interface IUnitOfCRM
    {
        IRepositoryBase<Cidade> CidadeRepositorio { get; }
        IRepositoryBase<UF> UfRepositorio { get; }
        IRepositoryBase<Modulo> ModuloRepositorio { get; }
        IRepositoryBase<Processo> ProcessoRepositorio { get; }

        Task CommitAsync();
    }
}
