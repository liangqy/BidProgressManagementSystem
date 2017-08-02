using Npgsql.EntityFrameworkCore.PostgreSQL;
using BidProgressManagementSystem.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace BidProgressManagementSystem.EntityFramework
{
    public  class MyDBContext: DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;User Id=lqy;Password=1239551904;Database=bid-mis-sys;");
        }


        public DbSet<UserBid> UserBids { get; set; }
        public DbSet<BidStatus> BidStatuses { get; set; }
        public DbSet<BidBidStatus> BidBidStatuses { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //UserRole关联配置
            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId).HasForeignKey(ur => ur.RoleId);
            //RoleMenu关联配置
            builder.Entity<RoleMenu>().HasKey(rm => new { rm.RoleId, rm.MenuId });
            builder.Entity<RoleMenu>().HasOne(rm => rm.Role).WithMany(r => r.RoleMenus).HasForeignKey(rm => rm.RoleId).HasForeignKey(rm => rm.MenuId);

            //UserBid关联配置
            builder.Entity<UserBid>().HasKey(ub => new { ub.UserId, ub.BidId });
            builder.Entity<UserBid>().HasOne(ub => ub.User).WithMany(u => u.UserBids).HasForeignKey(ub => ub.UserId).HasForeignKey(ub => ub.BidId);

            //BidBidStatus关联配置
            builder.Entity<BidBidStatus>().HasKey(bbs => new { bbs.BidId, bbs.StatusChangeTime ,bbs.StatusNowId,bbs.LastStatusId});
            builder.Entity<BidBidStatus>().HasOne(bbs => bbs.Bid).WithMany(bbs => bbs.BidBidStatuses).HasForeignKey(bbs => bbs.BidId).HasForeignKey(bbs => bbs.LastStatusId).HasForeignKey(bbs => bbs.StatusNowId);

          
            //启用Guid主键类型扩展
            builder.HasPostgresExtension("uuid-ossp");

            base.OnModelCreating(builder);
        }

    }
}
