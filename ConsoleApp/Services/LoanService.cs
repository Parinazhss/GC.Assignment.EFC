using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class LoanService
    {
        private readonly LoanRepository _loanRepository;
        private readonly UserService _userService;
        private readonly BookService _bookService;

        public LoanService(LoanRepository loanRepository, UserService userService, BookService bookService)
        {
            _loanRepository = loanRepository;
            _userService = userService;
            _bookService = bookService;
        }


        
      public LoanEntity CreateLoan(DateTime loanDate, DateTime returnDate,  string firstName, string lastName, string email, string roleName, string streetName, string city, string postalCode , string title, string writer)
            {
            var bookEntity = _bookService.CreateBook(title, writer);
            var userEntity = _userService.CreateUser(firstName, lastName, email, roleName, city, streetName, postalCode );

               

                // Create a new loan entity
                var loanEntity = new LoanEntity
                {
                   
                    LoanDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(30),
                    UserId = userEntity.Id,
                    BookId = bookEntity.Id, 
                };


            // Add the loan to the repository
            loanEntity = _loanRepository.Create(loanEntity);
                return loanEntity;
           
        
             }
        
        
        
        
        
       

        public LoanEntity GetLoanById(int id)
        {
            var LoanEntity = _loanRepository.Get(x => x.Id == id);


            return LoanEntity;
        }

        public IEnumerable<LoanEntity> GetAllLoans()
        {
            var loans = _loanRepository.GetAll();
            return loans;
        }

        public LoanEntity Update(LoanEntity loanEntity)
        {
            var updatedLoanEntity = _loanRepository.Update(x => x.Id == loanEntity.Id, loanEntity);
            return updatedLoanEntity;
        }

        public void Delete(int id)
        {
            _loanRepository.Delete(x => x.Id == id);
        }
    }
}
