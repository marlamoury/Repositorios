using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repositorios.Dominio.Entidades;
using Repositorios.Persistencia.Mapeamentos;

namespace Repositorios.Persistencia.Contexto
{
    public class RepositorioContexto : DbContext
    {
        public DbSet<Repositorio> Repositorios { get; set; }
        public IDbContextTransaction? Transacao { get; private set; }

        public RepositorioContexto(DbContextOptions<RepositorioContexto> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AplicarConfiguracoes(modelBuilder);
        }

        private void AplicarConfiguracoes(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RepositorioMap());
        }

        public IDbContextTransaction IniciarTransacao()
        {
            if (Transacao == null) Transacao = this.Database.BeginTransaction();
            return Transacao;
        }


        private void Reverter()
        {
            if (Transacao != null)
            {
                Transacao.Rollback();
            }
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                Reverter();
                throw new Exception(ex.Message);
            }
        }

        private void FinalizarTransacao()
        {
            if (Transacao != null)
            {
                Transacao.Commit();
                Transacao.Dispose();
                Transacao = null;
            }
        }

        public void Persistir()
        {
            Salvar();
            FinalizarTransacao();
        }
    }
}