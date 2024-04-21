using Aplication.Dtos.Planes;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers.Planes
{
    public class PlanMappingProfiles : Profile
    {
        public PlanMappingProfiles()
        {
            CreateMap<Plan, PlanDto>()
                .ForMember(dest => dest.Prima, opt => opt.MapFrom(src => src.ObtenerPrima()));
            CreateMap<PlanCobertura, PlanCoberturaDto>()
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Cobertura.Descripcion)
        );

        }
    }
}
