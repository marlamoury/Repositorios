using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Servicos.Interfaces
{
    public interface IRepositorioServico
    {
        int Adicionar(Repositorio repositorio);
        void Remover(int id);
        void Remover(Repositorio repositorio);
        Repositorio BuscarPorId(int id);
        IEnumerable<Repositorio> BuscarTodos();
        IEnumerable<LinguagemDTO> ObterLinguagens();
        RepositorioPaginacao ListarComPaginacao(string linguagem, int pagina, int quantidadePorPagina);
    }
}
