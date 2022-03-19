using Chillout.DataAccess.Core.Interfaces.DbContext;
using Chillout.DataAccess.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Chillout.DataAccess.Context
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) 
            : base(options)
        {
        }

        public DbSet<UserRto> Users { get; set; }
        public DbSet<PassListRto> PassList { get; set; }
        

    }
}
