using Microsoft.Extensions.DependencyInjection;
using Repositorios.Servicos.Interfaces;
using Repositorios.Servicos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Servicos.Auxiliares
{
    public static class InjetorServicos
    {
        public static void Registrar(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGitHubServico, GitHubServico>();
            serviceCollection.AddScoped<IRepositorioServico, RepositorioServico>();
        }
    }
}
