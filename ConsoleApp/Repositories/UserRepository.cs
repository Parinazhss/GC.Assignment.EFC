using ConsoleApp.Context;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories
{
    internal class UserRepository : BaseRepository<UserEntity>
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override UserEntity Get(Expression<Func<UserEntity, bool>> expression)
        {
            var entity = _context.Users
                .Include(i => i.Address)
                .Include(i => i.Role)
                .FirstOrDefault(expression);

            return entity!;
        }

        public override IEnumerable<UserEntity> GetAll()
        {
            return _context.Users
                .Include(i => i.Address)
                .Include(i => i.Role)
                .ToList();
        }
    }
}
