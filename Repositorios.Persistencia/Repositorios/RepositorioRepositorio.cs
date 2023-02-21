using Microsoft.EntityFrameworkCore;
using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;
using Repositorios.Persistencia.Contexto;
using Repositorios.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Persistencia.Repositorios
{
    public class RepositorioRepositorio : RepositorioBase<Repositorio>, IRepositorioRepositorio
    {
        public RepositorioRepositorio(RepositorioContexto contexto) : base(contexto)
        {
        }

        public RepositorioPaginacao ListarComPaginacao(string linguagem, int pagina, int quantidadePorPagina)
        {
            var consulta = Contexto.Repositorios
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

        public bool RepositorioJaFoiFavoritado(long codigo)
        {
            return Contexto.Repositorios.Any(a => a.Codigo == codigo);
        }
    }
}
