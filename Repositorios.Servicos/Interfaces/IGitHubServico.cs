using Octokit;
using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;

namespace Repositorios.Servicos.Interfaces
{
    public interface IGitHubServico
    {
        Task<RepositorioPaginacao> ObterRepositorios(string linguagem, int pagina, int quantidadePorPagina);
    }
}
