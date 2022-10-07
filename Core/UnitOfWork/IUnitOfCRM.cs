using Core.Repository;
using Core.Repository.Interface;
using Dominio;

namespace Core.UnitOfWork
{
    public interface IUnitOfCRM: IDisposable
    {
        public ModuloRepository moduloRepository { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
