using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public BookEntity CreateBook(string title , string writer)
        {
            var bookEntity = _bookRepository.Get(x => x.Title == title && x.Writer == writer);
            bookEntity ??= _bookRepository.Create(new BookEntity { Title = title, Writer = writer });

            return bookEntity;
        }

        public BookEntity GetBookByBookName(string title)
        {
            var bookEntity = _bookRepository.Get(x => x.Title == title);
            

            return bookEntity;
        }

        public BookEntity GetBookById(int id)
        {
            var bookEntity = _bookRepository.Get(x => x.Id == id);


            return bookEntity;
        }

        public IEnumerable<BookEntity> GetAllBooks()
        {
            var books = _bookRepository.GetAll();
            return books;
        }

        public BookEntity Update(BookEntity bookEntity)
        {
            var updatedBookEntity = _bookRepository.Update(x => x.Id == bookEntity.Id, bookEntity);
            return updatedBookEntity;
        }

        public void Delete(int id)
        {
           _bookRepository.Delete(x => x.Id == id);
        }
    }
}
