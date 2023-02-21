using AutoMapper;
using Octokit;
using Repositorios.Dominio.DTOs;
using Repositorios.Dominio.Entidades;

namespace Repositorios.Servicos.Mapeamentos
{
    public class RepositoryProfile : Profile
    {
        public RepositoryProfile()
        {
            CreateMap<Repository, Repositorio>()
                .ForMember(
                    dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Id)
                 )
                .ForMember(
                    dest => dest.QuantidadeEstrelas,
                    opt => opt.MapFrom(src => src.StargazersCount)
                 )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Name)
                 )
                .ForMember(
                    dest => dest.Proprietario,
                    opt => opt.MapFrom(src => src.Owner)
                )
                .ForMember(
                    dest => dest.Descricao,
                    opt => opt.MapFrom(src => src.Description)
                 )
                .ForMember(
                    dest => dest.Linguagem,
                    opt => opt.MapFrom(src => src.Language)
                 )
                .ForMember(
                    dest => dest.Id, 
                    opt => opt.Ignore()
                );
        }
    }
}
