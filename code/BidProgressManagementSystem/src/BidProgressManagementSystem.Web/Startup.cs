
using BidProgressManagementSystem.Application;
using BidProgressManagementSystem.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.IO;

namespace BidProgressManagementSystem
{

    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
		{
            //获取数据库连接字符串
            var sqlConnectionString = Configuration.GetConnectionString("default");

            //添加数据上下文
            services.AddDbContext<MyDBContext>(options =>
                options.UseNpgsql(sqlConnectionString)
            );
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddMvc();
            services.AddSession();
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
            }
            //app.UseMvcWithDefaultRoute();

            app.UseStaticFiles();
            //Session
            app.UseSession();

            app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
			});

			app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });

            SeedData.Initialize(app.ApplicationServices);
        }
    }
}
