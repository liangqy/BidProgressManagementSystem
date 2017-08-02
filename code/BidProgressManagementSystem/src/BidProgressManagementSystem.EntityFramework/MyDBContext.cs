using Npgsql.EntityFrameworkCore.PostgreSQL;
using BidProgressManagementSystem.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace BidProgressManagementSystem.EntityFramework
{
	public class MyDBContext: DbContext
    {
		public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("User ID=postgres;Password=BidDb;Host=localhost;Port=5432;Database=postgres;Pooling=true;");
		}

		public MyDBContext()
		{
		}

		public DbSet<UserBid> UserBids { get; set; }
		public DbSet<BidStatus> BidStatuses { get; set; }
		//public DbSet<BidBidStatus> BidBidStatuses { get; set; }
		public DbSet<Bid> Bids { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<RoleMenu> RoleMenus { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//UserRole关联配置
			builder.Entity<UserRole>()
			  .HasKey(ur => new { ur.UserId, ur.RoleId });

			//RoleMenu关联配置
			builder.Entity<RoleMenu>()
			  .HasKey(rm => new { rm.RoleId, rm.MenuId });
			builder.Entity<RoleMenu>()
			  .HasOne(rm => rm.Role)
			  .WithMany(r => r.RoleMenus)
			  .HasForeignKey(rm => rm.RoleId).HasForeignKey(rm => rm.MenuId);

			//启用Guid主键类型扩展
			builder.HasPostgresExtension("uuid-ossp");

			base.OnModelCreating(builder);
		}
	}
}
