using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Persistencia.Interfaces
{
    public interface IRepositorioRepositorio : IRepositorioBase<Repositorio>
    {
        bool RepositorioJaFoiFavoritado(long codigo);
        RepositorioPaginacao ListarComPaginacao(string linguagem, int pagina, int quantidadePorPagina);
    }
}
