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
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<PriceList>()
			//	.HasData(new PriceList[]
			//	{
			//		new ()
			//		{
			//			Id = 1,
			//			Name = "list1",
			//		},
			//		new ()
			//		{
			//			Id = 2,
			//			Name = "list2",
			//		},
			//	});

			//modelBuilder.Entity<Column>()
			//	.HasData(new Column[]
			//	{
			//		new ()
			//		{
			//			Id = 1,
			//			Name = "Name1",
			//		},
			//		new ()
			//		{
			//			Id = 2,
			//			Name = "Name2",
			//		},
			//		kind:
			//	});

			//modelBuilder.Entity<Item>()
			//	.HasData(new Item[]
			//	{
			//		new()
			//		{
			//			Id = 1,
			//			Name = "one",
			//			VendorCode = 111,
			//			PriceListId = 1,
			//		},
			//		new()
			//		{
			//			Id = 2,
			//			Name = "two",
			//			VendorCode = 222,
			//			PriceListId = 2,
			//		},
			//	});

			//modelBuilder.Entity<ColumnData>()
			//	.HasData(new ColumnData[]
			//	{
			//		new ()
			//		{
			//			Id = 1,
			//			NumberValue = 1,
			//			TextValue = "1 text in table",
			//			BooleanValue = true,
			//			ColumnId = 1,
			//			ItemId = 1
			//		},
			//		new ()
			//		{
			//			Id = 2,
			//			NumberValue = 2,
			//			TextValue = "2 text in table",
			//			BooleanValue = true,
			//			ColumnId = 2,
			//			ItemId = 2
			//		},
			//	});
		}
	}
}