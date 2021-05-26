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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<DTO.Category, Entities.Category>();
            CreateMap<IEnumerable<DTO.Category>, IEnumerable<Entities.Category>>();
        }
    }
}
