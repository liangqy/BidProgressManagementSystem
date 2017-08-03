﻿using Microsoft.EntityFrameworkCore;
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

                });
                context.Users.Add(new User
                {
                    UserName = "lqy",
                    Password = "123456",
                    Name = "测试管理员",

                });
                context.Roles.Add(new Role
                {
                    Name = "项目管理员",
                    CreateUserId = new Guid("30104d9a-da47-4ab8-be44-8541428c957a"),
                    CreateTime = DateTime.Now
                });
                context.Projects.Add(new Project
                {
                    Code = "001",
                    Name = "测试项目1",
                    DevelopmentOrganization = "测试招标公司1",
                    AgentOrganization = "测试代理公司1",
                    BidType ="工程总承包",
                    BidTime = DateTime.Now,
                });
                context.SaveChanges();
            }
        }
    }
}
