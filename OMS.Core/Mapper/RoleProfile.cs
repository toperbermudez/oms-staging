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
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<DTO.Role, Entities.Role>();
            CreateMap<IEnumerable<DTO.Role>,IEnumerable<Entities.Role>>();
        }
    }
}
