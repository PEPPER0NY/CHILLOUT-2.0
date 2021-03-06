using Chillout.DataAccess.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chillout.DataAccess.Core.Interfaces.DbContext1
{
    public interface IDbContext1 : IAsyncDisposable
    {
        public DbSet<UserRto> User { get; set; }
        public DbSet<PassListRto> PassList { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
