using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleEntity CreateRole(string roleName)
        {
            var bookEntity = _roleRepository.Get(x => x.RoleName == roleName);
            bookEntity ??= _roleRepository.Create(new RoleEntity { RoleName = roleName });

            return bookEntity;
        }

        public RoleEntity GetBookByRoleName(string roleName)
        {
            var bookEntity = _roleRepository.Get(x => x.RoleName == roleName);


            return bookEntity;
        }

        public RoleEntity GetBookById(int id)
        {
            var roleEntity = _roleRepository.Get(x => x.Id == id);


            return roleEntity;
        }

        public IEnumerable<RoleEntity> GetAllRoles()
        {
            var roles = _roleRepository.GetAll();
            return roles;
        }

        public RoleEntity Update(RoleEntity roleEntity)
        {
            var updatedRoleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
            return updatedRoleEntity;
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(x => x.Id == id);
        }
    }
}
