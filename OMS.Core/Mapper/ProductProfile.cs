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
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<DTO.Product, Entities.Product>();
            CreateMap<IEnumerable<DTO.Product>, IEnumerable<Entities.Product>>();
        }
    }
}
