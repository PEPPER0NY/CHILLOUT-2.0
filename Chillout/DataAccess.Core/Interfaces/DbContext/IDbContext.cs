using Chillout.DataAccess.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chillout.DataAccess.Core.Interfaces.DbContext
{
    public interface IDbContext : IDisposable, IAsyncDisposable
    {
        DbSet<UserRto> Users { get; set; }
        DbSet<HistoryGameRto> HistoryGames { get; set; }
        DbSet<HistoryMovement> HistoryMovement { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancelationToken = default);
    }
}
