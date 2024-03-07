using ExpertCenterTestTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTestTask.Data
{
	public class ApplicationContext : DbContext
	{
		public virtual DbSet<Column> Columns => Set<Column>();
		public virtual DbSet<PriceList> PriceLists => Set<PriceList>();
		public virtual DbSet<Item> Items => Set<Item>();
		public virtual DbSet<ColumnData> ColumnDatas => Set<ColumnData>();

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{ Database.EnsureCreated(); }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{ }
	}
}