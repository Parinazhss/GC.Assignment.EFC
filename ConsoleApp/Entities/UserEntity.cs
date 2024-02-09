using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    internal class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

       
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; } = null!;
       
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;

    }
}
