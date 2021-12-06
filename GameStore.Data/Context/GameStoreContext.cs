using GameStore.Domain.Entities.Games;
using GameStore.Domain.Entities.Notes;
using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Entities.Permission;
using GameStore.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data.Context
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGroup> GameGroups { get; set; }
        public DbSet<GameComment> GameComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Note> Notes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GameGroup>().HasData(new GameGroup
            //{
            //    Id = 1,
            //    Title = "Action",
            //    CreateDate = DateTime.Now
            //});
            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Id = 1,
            //    FullName = "Ehsan Fallah",
            //    Email = "ehsan@gmail.com",
            //    Mobile = "096856865656",
            //    Password = "ACyyE4V9m+/PxOOUbIGNlSwR0PGZo6R3O6RItUC685YJCemglt2ek20IfwDeNHnr2A==", // 1234
            //    CreateDate = DateTime.Now,
            //    EmailConfirm = true,
            //    IsActive = true,
            //});
            //base.OnModelCreating(modelBuilder);
        }
    }
}
