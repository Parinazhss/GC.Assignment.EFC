using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    internal class LoanEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime LoanDate { get; set; } 
        public DateTime ReturnDate { get; set; } 

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public int BookId { get; set; }
        public BookEntity Book { get; set; } = null!;
    }
}
