using Core.Context;
using Core.Repository;

namespace Core.UnitOfWork
{
    public class UnitOfCRM : IUnitOfCRM
    {
        private ModuloRepository? _moduloRepository;

        private readonly DapperContext _context;
        public UnitOfCRM(DapperContext dapperContext) { _context = dapperContext; }

        public void BeginTransaction()
        {
            _context.Transaction = _context.Connection?.BeginTransaction();
        }

        public void Commit()
        {
            _context.Transaction?.Commit();
            Dispose();
        }

        public void Dispose() => _context.Transaction?.Dispose();

        public void Rollback()
        {
            _context.Transaction?.Rollback();
            Dispose();
        }

        public ModuloRepository moduloRepository => _moduloRepository ?? (_moduloRepository = new ModuloRepository(_context));
    }
}
