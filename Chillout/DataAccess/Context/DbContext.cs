using Chillout.DataAccess.Core.Interfaces.DbContext;
using Chillout.DataAccess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chillout.DataAccess.Context
{
    public class DbContext1 : Microsoft.EntityFrameworkCore.DbContext, IDbContext 
    {
        public DbContext1(DbContextOptions<DbContext> options) 
            : base(options)
        {
            
        }
        
        public DbSet<UserRto> User { get; set; }
        public DbSet<PassListRto> PassList { get; set; }

    }
}
