using ConsoleApp.Context;
using ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories
{
    internal class BookRepository : BaseRepository<BookEntity>
    {
        public BookRepository(DataContext context) : base(context)
        {
        }
    }
}
