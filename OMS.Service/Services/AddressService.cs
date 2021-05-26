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
    public class AddressService : IAddressService
    {
        private readonly ICRUDRepository<Entities.Address> _addressRepo;
        public AddressService(ICRUDRepository<Entities.Address> addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public DTO.Response<DTO.Address> CreateAddress(DTO.Address address)
        {
            DTO.Response<DTO.Address> response = new DTO.Response<DTO.Address>();
            try
            {
                address.CreatedDate = DateTime.UtcNow;
                address.UpdatedDate = DateTime.UtcNow;
                _addressRepo.Add(Mapper.Map<DTO.Address, Entities.Address>(address));
                response.Success = true;
                response.Data = address;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Address GetAddressByAddressID(int addressID)
        {
            return Mapper.Map<Entities.Address, DTO.Address>(_addressRepo.GetSingle(u => u.ID.Equals(addressID)));
        }

        public IEnumerable<DTO.Address> ListAddresses()
        {
            return Mapper.Map<IEnumerable<Entities.Address>, IEnumerable<DTO.Address>>(_addressRepo.GetAll());
        }

        public DTO.Response<DTO.Address> RemoveAddress(int addressID)
        {
            DTO.Response<DTO.Address> response = new DTO.Response<DTO.Address>();
            try
            {
                Entities.Address address = _addressRepo.GetSingle(u => u.ID.Equals(addressID));
                _addressRepo.Remove(address);
                response.Success = true;
                response.Data = Mapper.Map<Entities.Address, DTO.Address>(address);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Response<DTO.Address> UpdateAddress(DTO.Address address)
        {
            address.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Address> response = new DTO.Response<DTO.Address>();
            try
            {
                _addressRepo.Update(Mapper.Map<DTO.Address, Entities.Address>(address));
                response.Success = true;
                response.Data = address;
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
