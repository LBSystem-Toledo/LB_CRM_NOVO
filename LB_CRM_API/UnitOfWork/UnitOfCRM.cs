using Dominio;
using LB_CRM_API.Context;
using LB_CRM_API.Repositories;

namespace LB_CRM_API.UnitOfWork
{
    public class UnitOfCRM : IUnitOfCRM
    {
        private ModuloRepository? _moduloRepository;
        private ProcessoRepository? _processoRepository;
        private AtividadeRepository _atividadeRepository;
        private CidadeRepository _cidadeRepository;
        private ClienteRepository _clienteRepository;
        private ClienteProcessoRepository _clienteProcessoRepository;
        private OperadorRepository _operadorRepository;
        private PacoteRepository _pacoteRepository;
        private ParceiroRepository _parceiroRepository;
        private UsuarioClienteRepository _usuarioClienteRepository;

        private readonly DapperContext _context;
        public UnitOfCRM(DapperContext dapperContext) { _context = dapperContext; }

        public async Task<bool> BeginTransactionAsync()
        {
            if (_context.Connection is not null)
            {
                if (await _context.OpenConnectionAsync())
                {
                    _context.Transaction = _context.Connection.BeginTransaction();
                    return true;
                }
                else return false;
            }
            else return false;
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

        public ModuloRepository ModuloRepository => _moduloRepository ?? (_moduloRepository = new ModuloRepository(new RepositoryBase<Modulo>(_context)));
        public ProcessoRepository ProcessoRepository => _processoRepository ?? (_processoRepository = new ProcessoRepository(new RepositoryBase<Processo>(_context)));
        public AtividadeRepository AtividadeRepository => _atividadeRepository ?? (_atividadeRepository = new AtividadeRepository(new RepositoryBase<Atividade>(_context)));
        public CidadeRepository CidadeRepository => _cidadeRepository ?? (_cidadeRepository = new CidadeRepository(new RepositoryBase<Cidade>(_context)));
        public ClienteRepository ClienteRepository => _clienteRepository ?? (_clienteRepository = new ClienteRepository(new RepositoryBase<Cliente>(_context)));
        public ClienteProcessoRepository ClienteProcessoRepository => _clienteProcessoRepository ?? (_clienteProcessoRepository = new ClienteProcessoRepository(new RepositoryBase<ClienteProcesso>(_context)));
        public OperadorRepository OperadorRepository => _operadorRepository ?? (_operadorRepository = new OperadorRepository(new RepositoryBase<Operador>(_context)));
        public PacoteRepository PacoteRepository => _pacoteRepository ?? (_pacoteRepository = new PacoteRepository(new RepositoryBase<Pacote>(_context)));
        public ParceiroRepository ParceiroRepository => _parceiroRepository ?? (_parceiroRepository = new ParceiroRepository(new RepositoryBase<Parceiro>(_context)));
        public UsuarioClienteRepository UsuarioClienteRepository => _usuarioClienteRepository ?? (_usuarioClienteRepository = new UsuarioClienteRepository(new RepositoryBase<UsuarioCliente>(_context)));
    }
}
