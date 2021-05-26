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
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<DTO.Address, Entities.Address>();
            CreateMap<IEnumerable<DTO.Address>, IEnumerable<Entities.Address>>();
        }
    }
}
