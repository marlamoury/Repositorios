using Microsoft.Extensions.DependencyInjection;
using Repositorios.Persistencia.Interfaces;
using Repositorios.Persistencia.Repositorios;

namespace Repositorios.Persistencia.Auxiliares
{
    public class InjetorRepositorios
    {
        public static void Registrar(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            serviceCollection.AddScoped<IRepositorioRepositorio, RepositorioRepositorio>();
        }
    }
}
