using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using Repositorios.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Testes
{
    public class GitHubServicoFake : IGitHubServico
    {
        private readonly List<Repositorio> _repositorios;

        public GitHubServicoFake()
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

        public async Task<RepositorioPaginacao> ObterRepositorios(string linguagem, int pagina, int quantidadePorPagina)
        {
            var repositorios = await Task.Factory.StartNew(() => _repositorios.Where(x => x.Linguagem.Equals(linguagem)).OrderBy(o => o.Id).Take(quantidadePorPagina).ToList());
            return new RepositorioPaginacao
            {
                Repositorios = repositorios,
                Total = repositorios.Count()
            };
        }
    }
}
