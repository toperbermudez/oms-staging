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
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<DTO.Order, Entities.Order>();
            CreateMap<IEnumerable<DTO.Order>, IEnumerable<Entities.Order>>();
        }
    }
}
