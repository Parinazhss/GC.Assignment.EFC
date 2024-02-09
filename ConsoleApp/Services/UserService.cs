using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly AddressService _addressService;
        private readonly RoleService _roleService;

        public UserService(UserRepository userRepository, AddressService addressService, RoleService roleService)
        {
            _userRepository = userRepository;
            _addressService = addressService;
            _roleService = roleService;
        }



        public UserEntity CreateUser(string firstName, string lastName, string email , string roleName , string city, string streetName, string postalCode)
        {
            var addressEntity = _addressService.CreateAddress(streetName, postalCode, city);
            var roleEntity = _roleService.CreateRole( roleName );

            var userEntity = new UserEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                RoleId = roleEntity.Id,
                AddressId = addressEntity.Id,
            };
            userEntity = _userRepository.Create( userEntity );
            return userEntity;
        }
        
        
        
        
        
        public UserEntity GetUserByEmail(string email)
        {
            var userEntity = _userRepository.Get(x => x.Email == email);


            return userEntity;
        }

        public UserEntity GetUserById(int id)
        {
            var userEntity = _userRepository.Get(x => x.Id == id);


            return userEntity;
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users;
        }

        public UserEntity Update(UserEntity userEntity)
        {
            var updatedUserEntity = _userRepository.Update(x => x.Id == userEntity.Id, userEntity);
            return updatedUserEntity;
        }

        public void Delete(int id)
        {
            _userRepository.Delete(x => x.Id == id);
        }
    }
}
