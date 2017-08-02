using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using BidProgressManagementSystem.EntityFramework;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BidProgressManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
			CreateDatabase();

			var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
		}

		private static void CreateDatabase()
		{
			using (var context = new MyDBContext())
			{
				context.Database.EnsureCreated();
			}
		}

	}
}
