using AutoMapper;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;
namespace OMS.Service.Services
{
    public class VariantService : IVariantService
    {
        private readonly ICRUDRepository<Entities.Variant> _variantRepo;
        public VariantService(ICRUDRepository<Entities.Variant> variantRepo)
        {
            _variantRepo = variantRepo;
        }

        public DTO.Response<DTO.Variant> CreateVariant(DTO.Variant variant)
        {
            DTO.Response<DTO.Variant> response = new DTO.Response<DTO.Variant>();
            try
            {
                variant.CreatedDate = DateTime.UtcNow;
                variant.UpdatedDate = DateTime.UtcNow;
                _variantRepo.Add(Mapper.Map<DTO.Variant, Entities.Variant>(variant));
                response.Success = true;
                response.Data = variant;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;

        }

        public DTO.Variant GetVariantByVariantID(int variantID)
        {
            return Mapper.Map<Entities.Variant, DTO.Variant>(_variantRepo.GetSingle(u => u.ID.Equals(variantID)));
        }

        public IEnumerable<DTO.Variant> ListVariants()
        {
            return Mapper.Map<IEnumerable<Entities.Variant>, IEnumerable<DTO.Variant>>(_variantRepo.GetAll());
        }


        public DTO.Response<DTO.Variant> RemoveVariant(int variantID)
        {
            DTO.Response<DTO.Variant> response = new DTO.Response<DTO.Variant>();
            try
            {
                Entities.Variant variant = _variantRepo.GetSingle(u => u.ID.Equals(variantID));
                _variantRepo.Remove(variant);
                response.Success = true;
                response.Data = Mapper.Map<Entities.Variant, DTO.Variant>(variant);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Response<DTO.Variant> UpdateVariant(DTO.Variant variant)
        {
            variant.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Variant> response = new DTO.Response<DTO.Variant>();
            try
            {
                _variantRepo.Update(Mapper.Map<DTO.Variant, Entities.Variant>(variant));
                response.Success = true;
                response.Data = variant;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;

        }
    }
}
