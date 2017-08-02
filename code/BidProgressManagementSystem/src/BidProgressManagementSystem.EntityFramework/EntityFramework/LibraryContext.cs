using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace BidProgressManagementSystem.EntityFramework
{
	public class LibraryContext : DbContext
	{
		public DbSet<Book> Book { get; set; }

		public DbSet<Publisher> Publisher { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=127.0.0.1;port=33060;database=library;user=homestead;password=secret;SslMode=none");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Publisher>(entity =>
			{
				entity.HasKey(e => e.ID);
				entity.Property(e => e.Name).IsRequired();
			});

			modelBuilder.Entity<Book>(entity =>
			{
				entity.HasKey(e => e.ISBN);
				entity.Property(e => e.Title).IsRequired();
				entity.HasOne(d => d.Publisher)
				  .WithMany(p => p.Books);
			});
		}
	}
}