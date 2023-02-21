using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Persistencia.Mapeamentos
{
    public class RepositorioMap : IEntityTypeConfiguration<Repositorio>
    {
        public void Configure(EntityTypeBuilder<Repositorio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).IsRequired().HasColumnName("Id");
            builder.Property(p => p.Codigo).IsRequired().HasColumnName("Codigo");
            builder.Property(p => p.Nome).IsRequired().HasColumnName("Nome");
            builder.Property(p => p.Proprietario).IsRequired().HasColumnName("Proprietario");
            builder.Property(p => p.HtmlUrl).IsRequired().HasColumnName("HtmlUrl");
            builder.Property(p => p.Descricao).IsRequired().HasColumnName("Descricao");
            builder.Property(p => p.Linguagem).IsRequired().HasColumnName("Linguagem");
            builder.Property(p => p.QuantidadeEstrelas).IsRequired().HasColumnName("QuantidadeEstrelas");
        }
    }
}
