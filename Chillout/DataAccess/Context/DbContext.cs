using Chillout.DataAccess.Core.Interfaces.DbContext;
using Chillout.DataAccess.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chillout.DataAccess.Context
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext, IDbContext
    {
        public DbContext(DbContextOptions<DbContext> options) 
            : base(options)
        {
        }

        public DbSet<UserRto> Users { get; set; }
        public DbSet<HistoryGameRto> HistoryGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoryGameRto>(builder => 
            {
                builder
                    .HasOne<UserRto>(e => e.LeftUser)
                    .WithMany(e => e.HistoryGamesLeftUser)
                    .HasForeignKey(e => e.LeftUserId)
                    .IsRequired();

                builder
                    .HasOne<UserRto>(e => e.RightUser)
                    .WithMany(e => e.HistoryGamesRightUser)
                    .HasForeignKey(e => e.RightUserId)
                    .IsRequired();

                builder
                    .HasOne<UserRto>(e => e.WinnerUser)
                    .WithMany(e => e.HistoryGamesWinnerUser)
                    .HasForeignKey(e => e.WinnerUserId)
                    .IsRequired();
            });
        }
    }
}
