using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace BidProgressManagementSystem.EntityFramework
{
	public class MyDBContext: DbContext
    {
		public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("User ID=postgres;Password=secret;Host=localhost;Port=5432;Database=bis-mis-sys;Pooling=true;");
		}

		public MyDBContext()
		{
		}

        public DbSet<UserProject> UserProjects { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<RoleMenu> RoleMenus { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//UserRole关联配置
			builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.Entity<UserRole>().HasOne(pt => pt.User).WithMany(p => p.UserRoles).HasForeignKey(pt => pt.UserId);

            //builder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(rm => rm.UserId).HasForeignKey;


            //RoleMenu关联配置
            builder.Entity<RoleMenu>().HasKey(rm => new { rm.RoleId, rm.MenuId });
            builder.Entity<RoleMenu>().HasOne(rm => rm.Role).WithMany(r => r.RoleMenus).HasForeignKey(rm => rm.RoleId);
            

            //UserProject关联配置?????
            builder.Entity<UserProject>().HasKey(up => new { up.UserId, up.ProjectId,up.Responsibility });
            builder.Entity<UserProject>().HasOne(u => u.User).WithMany(u => u.UserProjects).HasForeignKey(up => up.UserId);
            builder.Entity<UserProject>().HasOne(p => p.Project).WithMany(p => p.UserProjects).HasForeignKey(up => up.ProjectId);

            //启用Guid主键类型扩展
            builder.HasPostgresExtension("uuid-ossp");

			base.OnModelCreating(builder);
		}
	}
}
