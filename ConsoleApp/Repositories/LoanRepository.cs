using ConsoleApp.Context;
using ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories
{
    internal class LoanRepository : BaseRepository<LoanEntity>
    {
        private readonly DataContext _context;
        public LoanRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
