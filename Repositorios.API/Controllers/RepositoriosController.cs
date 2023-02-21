using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using Repositorios.Servicos;
using Repositorios.Servicos.Interfaces;

namespace Repositorios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoriosController : ControllerBase
    {
        private readonly IRepositorioServico _repositorioServico;
        public RepositoriosController(IRepositorioServico repositorioServico)
        {
            _repositorioServico = repositorioServico;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Listar()
        {
            try
            {
                var repositorios = _repositorioServico.BuscarTodos();
                return Ok(repositorios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarComPaginacao")]
        public IActionResult ListarComPaginacao(string linguagem, int pagina, int quantidadePorPagina)
        {
            try
            {
                var repositorios = _repositorioServico.ListarComPaginacao(linguagem, pagina, quantidadePorPagina);
                return Ok(repositorios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var repositorio = _repositorioServico.BuscarPorId(id);
                return Ok(repositorio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Repositorio repositorio)
        {
            try
            {
                var id = _repositorioServico.Adicionar(repositorio);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                _repositorioServico.Remover(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterLinguagens")]
        public IActionResult ObterLinguagens()
        {
            try
            {
                var linguagens = _repositorioServico.ObterLinguagens();
                return Ok(linguagens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
