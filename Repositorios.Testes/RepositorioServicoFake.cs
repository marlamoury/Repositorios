using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using Repositorios.Servicos.Interfaces;

namespace Repositorios.Testes
{
    public class RepositorioServicoFake : IRepositorioServico
    {
        private readonly List<Repositorio> _repositorios;
        public RepositorioServicoFake()
        {
            _repositorios = new List<Repositorio>() 
            {
                new Repositorio() 
                {
                    Id = 1,
                    Codigo = 1,
                    Nome = "Teste 1",
                    Descricao = "Teste 1",
                    HtmlUrl = "www.teste1.com.br",
                    Linguagem = "Php",
                    Proprietario = "Teste 1",
                    QuantidadeEstrelas = 10
                },
                new Repositorio()
                {
                    Id = 2,
                    Codigo = 2,
                    Nome = "Teste 2",
                    Descricao = "Teste 2",
                    HtmlUrl = "www.teste2.com.br",
                    Linguagem = "Java",
                    Proprietario = "Teste 2",
                    QuantidadeEstrelas = 9                
                },
                new Repositorio()
                {
                    Id = 3,
                    Codigo = 3,
                    Nome = "Teste 3",
                    Descricao = "Teste 3",
                    HtmlUrl = "www.teste3.com.br",
                    Linguagem = "CSharp",
                    Proprietario = "Teste 3",
                    QuantidadeEstrelas = 8
                },
                new Repositorio()
                {
                    Id = 4,
                    Codigo = 4,
                    Nome = "Teste 4",
                    Descricao = "Teste 4",
                    HtmlUrl = "www.teste4.com.br",
                    Linguagem = "Python",
                    Proprietario = "Teste 4",
                    QuantidadeEstrelas = 7
                },
                new Repositorio()
                {
                    Id = 5,
                    Codigo = 5,
                    Nome = "Teste 5",
                    Descricao = "Teste 5",
                    HtmlUrl = "www.teste5.com.br",
                    Linguagem = "JavaScript",
                    Proprietario = "Teste 5",
                    QuantidadeEstrelas = 6
                }
            };
        }

        public int Adicionar(Repositorio repositorio)
        {
            repositorio.Id = GerarId();
            _repositorios.Add(repositorio);
            return repositorio.Id;
        }

        public Repositorio BuscarPorId(int id)
        {
            var repositorio = _repositorios.First(f => f.Id == id);
            return repositorio;
        }

        public IEnumerable<Repositorio> BuscarTodos()
        {
            return _repositorios;
        }

        public RepositorioPaginacao ListarComPaginacao(string linguagem, int pagina, int quantidadePorPagina)
        {
            var consulta = _repositorios
                .Where(x => x.Linguagem.Equals(linguagem));

            var total = consulta.Count();

            var repositorios = consulta
                .OrderBy(o => o.Id)
                .Skip(pagina > 0 ? quantidadePorPagina * pagina : 0)
                .Take(quantidadePorPagina)
                .ToList();

            return new RepositorioPaginacao
            {
                Total = total,
                Repositorios = repositorios
            };
        }

        public IEnumerable<LinguagemDTO> ObterLinguagens()
        {
            var linguagens = new List<LinguagemDTO>()
            {
                new LinguagemDTO
                {
                    Id = 1,
                    Descricao = "CSharp"
                },
                new LinguagemDTO
                {
                    Id = 2,
                    Descricao = "Java"
                },
                new LinguagemDTO
                {
                    Id = 3,
                    Descricao = "Python"
                },
                new LinguagemDTO
                {
                    Id = 4,
                    Descricao = "JavaScript"
                },
                new LinguagemDTO
                {
                    Id = 5,
                    Descricao = "Php"
                },
            };

            return linguagens;
        }

        public void Remover(int id)
        {
            var repositorio = BuscarPorId(id);
            Remover(repositorio);
        }

        public void Remover(Repositorio repositorio)
        {
            _repositorios.Remove(repositorio);
        }
        private int GerarId()
        {
            return _repositorios.Max(m => m.Id) + 1;
        }
    }
}
