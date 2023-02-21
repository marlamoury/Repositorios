using AutoMapper;
using Octokit;
using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using Repositorios.Servicos.Extensoes;
using Repositorios.Servicos.Interfaces;

namespace Repositorios.Servicos.Servicos
{
    public class GitHubServico : IGitHubServico
    {
        private readonly IGitHubClient _gitHubClient;
        private readonly IMapper _mapper;
        public GitHubServico(IMapper mapper)
        {
            _gitHubClient = new GitHubClient(new ProductHeaderValue("marlamoury"));
            _mapper = mapper;
        }

        public async Task<RepositorioPaginacao> ObterRepositorios(string linguagem, int pagina, int quantidadePorPagina)
        {
            var linguagemEnum = linguagem.ObterEnumeradorDeLinguagem();

            var resultado = await BuscarRepositorios(linguagemEnum, pagina, quantidadePorPagina);

            var repositorios = MapearParaRepositorios(resultado);

            return new RepositorioPaginacao
            {
                Total = resultado.TotalCount,
                Repositorios = repositorios
            };
        }

        private async Task<SearchRepositoryResult> BuscarRepositorios(Language linguagem, int pagina, int quantidadePorPagina) =>
            await _gitHubClient.Search.SearchRepo(ObterParametrosDaRequisicao(linguagem, pagina, quantidadePorPagina));

        private SearchRepositoriesRequest ObterParametrosDaRequisicao(Language linguagem, int pagina, int quantidadePorPagina)
        {
            return new SearchRepositoriesRequest
            {
                Language = linguagem,
                SortField = RepoSearchSort.Stars,
                Order = SortDirection.Descending,
                PerPage = quantidadePorPagina,
                Page = pagina
            };
        }

        private List<Repositorio> MapearParaRepositorios(SearchRepositoryResult resultado) => 
            _mapper.Map<IReadOnlyList<Repository>, List<Repositorio>>(resultado.Items);
    }
}