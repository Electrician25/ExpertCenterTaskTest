using ExpertCenterTestTask.CrudServices;
using ExpertCenterTestTask.Data;
using ExpertCenterTestTask.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace TestApp
{
	public class PriceListTests
	{
		public async Task<ApplicationContext> GetDatabaseContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
			var databaseContext = new ApplicationContext(options);
			databaseContext.Database.EnsureCreated();
			if (await databaseContext.PriceLists.CountAsync() <= 0)
			{
				databaseContext.PriceLists.Add(new PriceList()
				{
					Id = 1,
					Name = "testName1",
					Columns = new[]
					{
						new Column { Name = "firstColumn" },
					},
					Items = new[]
					{
						new Item
						{
							Id = 2,
							Name = "cup",
							VendorCode = 312,
							PriceListId = 1
						}
					}
				});
				await databaseContext.SaveChangesAsync();
			}
			return databaseContext;
		}

		[Fact]
		public async void WhenAddingPriceList_AndPriceListIdIsUnique_NotThrowException()
		{
			// Arrange.
			var id = 1;
			var dbContext = await GetDatabaseContext();
			var crud = new PriceListsCrud(dbContext);

			// Act.
			var result = () => crud.GetPriceListByIdAsync(id);

			// Assert.
			await result.Should().NotThrowAsync<Exception>();
		}

		[Fact]
		public async void WhenAddingPriceList_AndPriceListIdIsNotCorrect_ThrowException()
		{
			// Arrange.
			var id = 242;
			var dbContext = await GetDatabaseContext();
			var crud = new PriceListsCrud(dbContext);

			// Act.
			var result = () => crud.GetPriceListByIdAsync(id);

			// Assert.
			await result.Should().ThrowAsync<Exception>();
		}

		[Fact]
		public async void WhenAddingPriceList_AndPriceListAlreadyExist_ThrowExeption()
		{
			var list = new PriceList()
			{
				Id = 1,
				Name = "testName1",
				Columns = new[]
				{
					new Column { Name = "firstColumn" },
				},
				Items = new[]
				{
					new Item
					{
						Id = 2,
						Name = "cup",
						VendorCode = 312,
						PriceListId = 1
					}
				}
			};
			var dbContext = await GetDatabaseContext();
			var crud = new PriceListsCrud(dbContext);

			// Act.
			var result = () => crud.AddNewPriceListAsync(list);

			// Assert.
			await result.Should().ThrowAsync<Exception>();
		}

		[Fact]
		public async void WhenAddingPriceList_AndPriceListIsCorrect_NotThrowException()
		{
			// Arrange.
			var newPriceList = new PriceList 
			{
				Id = 55, 
				Name = "apple",
				Columns = new Column[] 
				{ 
					new () { Id = 55,Name = "column55"} 
				},
				Items = new Item[]
				{
					new () { Id = 55, Name = "item55",PriceListId = 55}	
				}
			};
			var dbContext = await GetDatabaseContext();
			var crud = new PriceListsCrud(dbContext);

			// Act.
			var result = () => crud.AddNewPriceListAsync(newPriceList);

			// Assert.
			await result.Should().NotThrowAsync<Exception>();
		}
	}
}