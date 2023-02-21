using Microsoft.AspNetCore.Mvc;
using Repositorios.API.Controllers;
using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using Repositorios.Servicos.Interfaces;

namespace Repositorios.Testes
{
    public class RepositoriosControllerTeste
    {
        private readonly IRepositorioServico _servico;
        private readonly RepositoriosController _controller;

        public RepositoriosControllerTeste()
        {
            _servico = new RepositorioServicoFake();
            _controller = new RepositoriosController(_servico);
        }

        [Fact]
        public void Listar_QuandoChamado_RetornaOkResult()
        {
            var resultado = _controller.Listar();
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Listar_QuandoChamado_RetornaTodosItens()
        {
            var resultado = _controller.Listar() as OkObjectResult;
            var repositorios = Assert.IsType<List<Repositorio>>(resultado?.Value);
            Assert.Equal(5, repositorios.Count);
        }

        [Fact]
        public void BuscarPorId_QuandoChamado_RetornaOkResult()
        {
            var resultado = _controller.BuscarPorId(1);
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void BuscarPorId_QuandoChamado_RetornaBadRequestResult()
        {
            var resultado = _controller.BuscarPorId(99);
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void BuscarPorId_QuandoChamado_RetornaRepositorio()
        {
            var resultado = _controller.BuscarPorId(1) as OkObjectResult;
            var repositorios = Assert.IsType<Repositorio>(resultado?.Value);
            Assert.IsType<Repositorio>(repositorios);
        }

        [Fact]
        public void Adicionar_QuandoChamado_RetornaOkResult()
        {
            var repositorio = new Repositorio
            {
                Codigo = 6,
                Nome = "Teste 6",
                Descricao = "Teste 6",
                HtmlUrl = "www.teste6.com.br",
                Linguagem = "JavaScript",
                Proprietario = "Teste 6",
                QuantidadeEstrelas = 6
            };

            var resultado = _controller.Adicionar(repositorio);
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Remover_QuandoChamado_RetornaOkResult()
        {
            var resultado = _controller.Remover(5);
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Remover_QuandoChamado_RetornaBadRequestResult()
        {
            var resultado = _controller.Remover(99);
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void ObterLinguagens_QuandoChamado_RetornaOkResult()
        {
            var resultado = _controller.ObterLinguagens();
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void ObterLinguagens_QuandoChamado_RetornaTodosItens()
        {
            var resultado = _controller.ObterLinguagens() as OkObjectResult;
            var repositorios = Assert.IsType<List<LinguagemDTO>>(resultado?.Value);
            Assert.Equal(5, repositorios.Count);
        }

        [Fact]
        public void ListarComPaginacao_QuandoChamado_RetornaOkResult()
        {
            var resultado = _controller.ListarComPaginacao("Java", 0, 10);
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void ListarComPaginacao_QuandoChamado_RetornaTodosItens()
        {
            var resultado = _controller.ListarComPaginacao("Java", 0, 10) as OkObjectResult;
            var repositorio = Assert.IsType<RepositorioPaginacao>(resultado?.Value);
            Assert.True(repositorio.Repositorios.Count() > 0);
        }
    }
}
