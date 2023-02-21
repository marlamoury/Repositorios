using Microsoft.AspNetCore.Mvc;
using Repositorios.API.Controllers;
using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using Repositorios.Servicos.Interfaces;

namespace Repositorios.Testes
{
    public class GitHubControllerTeste
    {
        private readonly IGitHubServico _servico;
        private readonly GitHubController _controller;

        public GitHubControllerTeste()
        {
            _servico = new GitHubServicoFake();
            _controller = new GitHubController(_servico);
        }

        [Fact]
        public void ListarRepositorios_QuandoChamado_RetornaOkResult()
        {
            var resultado = _controller.ListarRepositorios("Java", 1, 10).Result;
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void ListarRepositorios_QuandoChamado_RetornaTodosItens()
        {
            var resultado = _controller.ListarRepositorios("Java", 1, 10).Result as OkObjectResult;
            var repositorioPaginacao = Assert.IsType<RepositorioPaginacao>(resultado?.Value);
            Assert.True(repositorioPaginacao.Repositorios.Count() > 0);
        }
    }
}
