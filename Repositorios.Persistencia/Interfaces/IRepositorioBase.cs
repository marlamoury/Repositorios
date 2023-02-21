using Repositorios.Dominio.Entidades;

namespace Repositorios.Persistencia.Interfaces
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        int Adicionar(T entidade);
        void Remover(int id);
        void Remover(T entidade);
        T BuscarPorId(int id);
        IEnumerable<T> BuscarTodos();
    }
}
