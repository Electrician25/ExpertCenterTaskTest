using ExpertCenterTestTask.Data;
using ExpertCenterTestTask.Entities;

namespace ExpertCenterTestTask.CrudServices
{
	public class ItemCrud
	{
		private readonly ApplicationContext _ApplicationContext;

		public ItemCrud(ApplicationContext applicationContext)
		{
			_ApplicationContext = applicationContext;
		}

		async public Task<Item> AddItemAsync(Item item)
		{
			if (item is null)
			{
				throw new Exception();
			}

			await _ApplicationContext.Items.AddAsync(item);
			_ApplicationContext.SaveChanges();

			return item;
		}

		async public Task<Item> DeleteItemAsync(int id)
		{
			var itemId = await _ApplicationContext.Items.FindAsync(id)
				?? throw new Exception();

			_ApplicationContext.Remove(itemId);
			_ApplicationContext.SaveChanges();

			return itemId;
		}
	}
}