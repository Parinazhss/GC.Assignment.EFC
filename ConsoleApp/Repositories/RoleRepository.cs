using ConsoleApp.Context;
using ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories
{
    internal class RoleRepository : BaseRepository<RoleEntity>
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }
    }
}
