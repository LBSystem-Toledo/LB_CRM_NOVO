using LB_CRM_API.Repositories;
using LB_CRM_API.Repositories.Interface;
using Dominio;

namespace LB_CRM_API.UnitOfWork
{
    public interface IUnitOfCRM: IDisposable
    {
        public ModuloRepository ModuloRepository { get; }
        public ProcessoRepository ProcessoRepository { get; }
        public AtividadeRepository AtividadeRepository { get; }
        public CidadeRepository CidadeRepository { get; }
        public ClienteRepository ClienteRepository { get; }
        public ClienteProcessoRepository ClienteProcessoRepository { get; }
        public OperadorRepository OperadorRepository { get; }
        public PacoteRepository PacoteRepository { get; }
        public ParceiroRepository ParceiroRepository { get; }
        public UsuarioClienteRepository UsuarioClienteRepository { get; }

        Task<bool> BeginTransactionAsync();
        void Commit();
        void Rollback();
    }
}
