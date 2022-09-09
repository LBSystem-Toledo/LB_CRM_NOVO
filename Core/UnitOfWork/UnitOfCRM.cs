using Core.Context;
using Core.Repository;
using Core.Repository.Interface;
using Dominio;

namespace Core.UnitOfWork
{
    public class UnitOfCRM : IUnitOfCRM, IDisposable
    {
        private readonly DataContext _context;
        private RepositoryBase<Cidade>? _cidadeRepositorio = null;
        private RepositoryBase<UF>? _ufRepositorio = null;
        private RepositoryBase<Modulo>? _moduloRepositorio = null;
        private RepositoryBase<Processo>? _processoRepositorio = null;
        private bool disposed = false;

        public UnitOfCRM(DataContext dataContext) { _context = dataContext; }

        public IRepositoryBase<Cidade> CidadeRepositorio
        {
            get
            {
                if (_cidadeRepositorio == null)
                    _cidadeRepositorio = new RepositoryBase<Cidade>(_context.Set<Cidade>());
                return _cidadeRepositorio;
            }
        }
        public IRepositoryBase<UF> UfRepositorio
        {
            get
            {
                if (_ufRepositorio == null)
                    _ufRepositorio = new RepositoryBase<UF>(_context.Set<UF>());
                return _ufRepositorio;
            }
        }
        public IRepositoryBase<Modulo> ModuloRepositorio
        {
            get
            {
                if (_moduloRepositorio == null)
                    _moduloRepositorio = new RepositoryBase<Modulo>(_context.Set<Modulo>());
                return _moduloRepositorio;
            }
        }
        public IRepositoryBase<Processo> ProcessoRepositorio
        {
            get
            {
                if (_processoRepositorio == null)
                    _processoRepositorio = new RepositoryBase<Processo>(_context.Set<Processo>());
                return _processoRepositorio;
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _context.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
