using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyDBContext(serviceProvider.GetRequiredService<DbContextOptions<MyDBContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.Users.Add(new User
                {
                    UserName = "admin",
                    Password = "123456",
                    Name = "超级管理员",
                    IsSupervisor = true

                });
                context.Users.Add(new User
                {
                    UserName = "lqy",
                    Password = "123456",
                    Name = "测试管理员",
                    IsSupervisor = false
                });
                context.Users.Add(new User
                {
                    UserName = "www",
                    Password = "123456",
                    Name = "测试1",
                    IsSupervisor = false
                });
                context.Roles.Add(new Role
                {
                    Name = "项目管理员",
                });
                context.Roles.Add(new Role
                {
                    Name = "普通人员",
                });
                context.Projects.Add(new Project
                {
                    Code = "001",
                    Name = "测试项目1",
                    DevelopmentOrganization = "测试招标公司1",
                    AgentOrganization = "测试代理公司1",
                    BidType = "工程总承包",
                    BidTime = DateTime.Now,
                });
                context.Projects.Add(new Project
                {
                    Code = "002",
                    Name = "测试项目2",
                    DevelopmentOrganization = "测试招标公司2",
                    AgentOrganization = "测试代理公司2",
                    BidType = "工程总承包",
                    BidTime = DateTime.Now,
                });
                context.Projects.Add(new Project
                {
                    Code = "003",
                    Name = "测试项目3",
                    DevelopmentOrganization = "测试招标公司3",
                    AgentOrganization = "测试代理公司3",
                    BidType = "工程总承包",
                    BidTime = DateTime.Now,
                });
                context.Projects.Add(new Project
                {
                    Code = "004",
                    Name = "测试项目4",
                    DevelopmentOrganization = "测试招标公司2",
                    AgentOrganization = "测试代理公司3",
                    BidType = "设计",
                    BidTime = DateTime.Now,
                });
                context.Projects.Add(new Project
                {
                    Code = "005",
                    Name = "测试项目5",
                    DevelopmentOrganization = "测试招标公司2",
                    AgentOrganization = "测试代理公司3",
                    BidType = "物资",
                    BidTime = DateTime.Now,
                });
				Menu parentMenu = new Menu {
					Code = "001",
					Name = "系统管理",
					SerialNumber=1,
					Type=1,
				};
				context.Menus.Add(parentMenu);
				context.Menus.Add(new Menu
				{
					Code="001",
					Name = "用户管理",
					ParentId = parentMenu.Id,
					SerialNumber = 1,
					Type = 0,
					Url="User",
				});
				context.Menus.Add(new Menu
				{
					Code = "002",
					Name = "角色管理",
					ParentId = parentMenu.Id,
					SerialNumber = 1,
					Type = 0,
					Url = "Role",
				});
				context.Menus.Add(new Menu
				{
					Code = "003",
					Name = "菜单管理",
					ParentId = parentMenu.Id,
					SerialNumber = 1,
					Type = 0,
					Url = "Menu",
				});
				context.Menus.Add(new Menu
				{
					Code = "004",
					Name = "投标管理",
					ParentId = parentMenu.Id,
					SerialNumber = 1,
					Type = 0,
					Url = "Project",
				});
				context.SaveChanges();



                //List<User> users = context.Users.ToList();
                //List<Role> roles = context.Roles.ToList();
                //List<Project> projects = context.Projects.ToList();

                //UserRole userrole1 = new UserRole();
                //userrole1.User = users[1];
                //userrole1.UserId = users[1].Id;
                //userrole1.Role = roles[0];
                //userrole1.RoleId = roles[0].Id;

                //UserRole userrole2 = new UserRole();
                //userrole1.User = users[2];
                //userrole1.UserId = users[2].Id;
                //userrole1.Role = roles[1];
                //userrole1.RoleId = roles[1].Id;

                //context.UserRoles.Add(userrole1);
                //context.UserRoles.Add(userrole2);
                //context.SaveChanges();


                //UserProject userproject1 = new UserProject();
                //userproject1.User = users[1];
                //userproject1.UserId = users[1].Id;
                //userproject1.Project = projects[0];
                //userproject1.UserId = projects[0].Id;
                //userproject1.Responsibility = 1;

                //UserProject userproject2 = new UserProject();
                //userproject2.User = users[1];
                //userproject2.UserId = users[1].Id;
                //userproject2.Project = projects[1];
                //userproject2.UserId = projects[1].Id;
                //userproject2.Responsibility = 2;

                //UserProject userproject3 = new UserProject();
                //userproject3.User = users[2];
                //userproject3.UserId = users[2].Id;
                //userproject3.Project = projects[2];
                //userproject3.UserId = projects[2].Id;
                //userproject3.Responsibility = 1;

                //UserProject userproject4 = new UserProject();
                //userproject4.User = users[2];
                //userproject4.UserId = users[2].Id;
                //userproject4.Project = projects[3];
                //userproject4.UserId = projects[3].Id;
                //userproject4.Responsibility = 2;

                //UserProject userproject5 = new UserProject();
                //userproject5.User = users[2];
                //userproject5.UserId = users[2].Id;
                //userproject5.Project = projects[4];
                //userproject5.UserId = projects[4].Id;
                //userproject5.Responsibility = 3;

                //context.UserProjects.Add(userproject1);
                //context.UserProjects.Add(userproject2);
                //context.UserProjects.Add(userproject3);
                //context.UserProjects.Add(userproject4);
                //context.UserProjects.Add(userproject5);


                //context.SaveChanges();


            }
        }
    }
}
