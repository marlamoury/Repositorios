using AutoMapper;
using Octokit;
using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using Repositorios.Persistencia.Interfaces;
using Repositorios.Servicos.Extensoes;
using Repositorios.Servicos.Interfaces;

namespace Repositorios.Servicos.Servicos
{
    public class RepositorioServico : IRepositorioServico
    {
        private readonly IRepositorioRepositorio _repositorio;
        private readonly IMapper _mapper;
        public RepositorioServico(IRepositorioRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public virtual int Adicionar(Repositorio repositorio)
        {
            if (_repositorio.RepositorioJaFoiFavoritado(repositorio.Codigo))
                throw new Exception($"O repositorio \"{repositorio.Nome}\" já foi favoritado!");

            //HACK: Conversão necessária devido a ambiguidade entre nomeclatura de linguagem
            repositorio.Linguagem = repositorio.Linguagem.Equals("C#") ? Language.CSharp.ObterTextoEnumerador() : repositorio.Linguagem;

            return _repositorio.Adicionar(repositorio);
        }
        public virtual Repositorio BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public virtual IEnumerable<Repositorio> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public virtual void Remover(int id)
        {
            _repositorio.Remover(id);
        }

        public virtual void Remover(Repositorio repositorio)
        {
            _repositorio.Remover(repositorio);
        }

        public IEnumerable<LinguagemDTO> ObterLinguagens()
        {
            var linguagens = new List<Language> { Language.CSharp, Language.Python, Language.JavaScript, Language.Java, Language.Php };
            return _mapper.Map<List<Language>, IEnumerable<LinguagemDTO>>(linguagens);
        }

        public RepositorioPaginacao ListarComPaginacao(string linguagem, int pagina, int quantidadePorPagina)
        {
            return _repositorio.ListarComPaginacao(linguagem, pagina, quantidadePorPagina);
        }
    }
}
