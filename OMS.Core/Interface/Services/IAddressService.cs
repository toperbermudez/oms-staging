using OMS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Interface.Services
{
    public interface IAddressService
    {
        IEnumerable<Address> ListAddresses();

        Response<Address> CreateAddress(Address address);

        Response<Address> UpdateAddress(Address address);

        Response<Address> RemoveAddress(int addressID);

        Address GetAddressByAddressID(int addressID);
    }
}
