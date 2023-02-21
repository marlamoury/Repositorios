using Microsoft.EntityFrameworkCore;
using Repositorios.Dominio.Entidades;
using Repositorios.Persistencia.Interfaces;
using Repositorios.Persistencia.Contexto;

namespace Repositorios.Persistencia.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase
    {
        protected readonly RepositorioContexto Contexto;

        public RepositorioBase(RepositorioContexto contexto) : base()
        {
            Contexto = contexto;
        }

        public int Adicionar(T entidade)
        {
            Contexto.IniciarTransacao();
            Contexto.Set<T>().Add(entidade);
            Contexto.Persistir();
            return entidade.Id;
        }

        public T BuscarPorId(int id)
        {
            return Contexto.Set<T>().Find(id);
        }

        public IEnumerable<T> BuscarTodos()
        {
            return Contexto.Set<T>().ToList();
        }

        public void Remover(int id)
        {
            Contexto.IniciarTransacao();
            var entidade = BuscarPorId(id);
            if (entidade != null)
            {
                Contexto.Set<T>().Remove(entidade);
                Contexto.Persistir();
            }
        }

        public void Remover(T entidade)
        {
            Contexto.IniciarTransacao();
            Contexto.Set<T>().Remove(entidade);
            Contexto.Persistir();
        }
    }
}
