using Repositorios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Dominio.DTOs
{
    public class RepositorioPaginacao
    {
        public List<Repositorio> Repositorios { get; set; }
        public long Total { get; set; }
    }
}
