using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;

namespace OMS.Core.Mapper
{
    public class VariantProfile : Profile
    {
        public VariantProfile()
        {
            CreateMap<DTO.Variant, Entities.Variant>();
            CreateMap<IEnumerable<DTO.Variant>, IEnumerable<Entities.Variant>>();
        }
    }
}
