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
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<DTO.Transaction, Entities.Transaction>();
            CreateMap<IEnumerable<DTO.Transaction>, IEnumerable<Entities.Transaction>>();
        }
    }
}
