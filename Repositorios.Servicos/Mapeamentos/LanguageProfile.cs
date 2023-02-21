using AutoMapper;
using Octokit;
using Repositorios.Dominio.DTOs;
using Repositorios.Servicos.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Servicos.Mapeamentos
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Language, LinguagemDTO>()
                .ForMember(
                    opt => opt.Id,
                    dest => dest.MapFrom(src => (int)src)
                )
                .ForMember(
                    opt => opt.Descricao,
                    dest => dest.MapFrom(src => src.ObterTextoEnumerador())
                );
        }
    }
}
