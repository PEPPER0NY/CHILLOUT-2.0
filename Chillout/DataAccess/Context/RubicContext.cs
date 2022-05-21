using Chillout.DataAccess.Core.Interfaces.DbContext1;
using Chillout.DataAccess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chillout.DataAccess.Context
{
    public class RubicContext : DbContext, IDbContext
    {
        public RubicContext(DbContextOptions<RubicContext> options)
            : base(options)
        {

        }

        public DbSet<UserRto> User { get; set; }
        public DbSet<PassListRto> PassList { get; set; }

    }
}
