using Application.Features.Product.Commands;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand,Domain.Entities.Product>();

            /* This code is required when source and destination have different property name
            CreateMap<CreateProductCommand, Domain.Entities.Product>().ForMember(dest=>dest.description,source=>source.MapFrom(src=>src.description)); */
        }
    }
}
