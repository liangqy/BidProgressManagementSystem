using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using BidProgressManagementSystem.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BidProgressManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
			//PrintData();

			var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();

		}

		private static void PrintData()
		{
			// Gets and prints all books in database
			using (var context = new LibraryContext())
			{
				var books = context.Book
				  .Include(p => p.Publisher);
				foreach (var book in books)
				{
					var data = new StringBuilder();
					data.AppendLine($"ISBN: {book.ISBN}");
					data.AppendLine($"Title: {book.Title}");
					data.AppendLine($"Publisher: {book.Publisher.Name}");
					Console.WriteLine(data.ToString());
				}
			}
		}
	}
}
