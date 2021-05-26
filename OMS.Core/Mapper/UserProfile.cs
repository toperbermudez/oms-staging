using AutoMapper;
using OMS.Core.DTO;
using OMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile() {

        CreateMap<DTO.User, Entities.User>();


            
        }
    }
}
