using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Core.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Modulo>? Modulos { get; set; }
        public virtual DbSet<Processo>? Processos { get; set; }
        public virtual DbSet<UF>? Ufs { get; set; }
        public virtual DbSet<Cidade>? Cidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Modulo>()
                .ToTable("TB_Modulo")
                .HasKey(x => x.Id);
            modelBuilder
                .Entity<Processo>(entity =>
                {
                    entity.ToTable("TB_Processo");
                    entity.HasKey(p => p.Id);
                    entity.HasOne(p => p.Modulo)
                    .WithMany(p => p.Processos)
                    .HasForeignKey(p => p.ModuloId);
                });
            modelBuilder
                .Entity<UF>()
                .ToTable("TB_UF")
                .HasKey(p => p.Cd_uf);
            modelBuilder
                .Entity<Cidade>(entity =>
                {
                    entity.ToTable("TB_Cidade")
                    .HasKey(p => p.Cd_cidade);
                    entity.HasOne(p => p.Uf)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(p => p.Cd_uf);
                });
        }
    }
}
