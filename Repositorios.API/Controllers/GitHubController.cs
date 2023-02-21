using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorios.Servicos.Interfaces;

namespace Repositorios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubServico _gitHubServico;

        public GitHubController(IGitHubServico gitHubServico)
        {
            _gitHubServico = gitHubServico;
        }

        [HttpGet]
        [Route("ListarRepositorios")]
        public async Task<IActionResult> ListarRepositorios(string linguagem, int pagina, int quantidadePorPagina)
        {
            try
            {
                var repositorios = await _gitHubServico.ObterRepositorios(linguagem, pagina, quantidadePorPagina);
                return Ok(repositorios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
