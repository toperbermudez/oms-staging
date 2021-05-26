using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Mapper
{
    public static class AutoMapperCoreConfiguration
    {
        public static void Configure()
        {
           AutoMapper.Mapper.Initialize(cfg => {
               cfg.AddProfile<UserProfile>();
               cfg.AddProfile<RoleProfile>();
               cfg.AddProfile<ProductProfile>();
               cfg.AddProfile<CategoryProfile>();
               cfg.AddProfile<VariantProfile>();
               cfg.AddProfile<AddressProfile>();
           });
        }
    }
}
