using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }




        public AddressEntity CreateAddress(string streetName, string postalCode, string city)
        {
            var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.City == city && x.PostalCode == postalCode);
            addressEntity ??= _addressRepository.Create(new AddressEntity { StreetName = streetName, City = city, PostalCode = postalCode  });

            return addressEntity;
        }

        public AddressEntity GetAddress(string streetName, string postalCode, string city)
        {
            var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.City == city && x.PostalCode == postalCode);


            return addressEntity;
        }

        public AddressEntity GetBookById(int id)
        {
            var addressEntity = _addressRepository.Get(x => x.Id == id);


            return addressEntity;
        }

        public IEnumerable<AddressEntity> GetAddresses()
        {
            var addresses = _addressRepository.GetAll();
            return addresses;
        }

        public AddressEntity Update(AddressEntity addressEntity)
        {
            var updatedAddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
            return updatedAddressEntity;
        }

        public void Delete(int id)
        {
            _addressRepository.Delete(x => x.Id == id);
        }
    }
}
