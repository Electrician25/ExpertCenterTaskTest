using ExpertCenterTestTask.CrudServices;
using ExpertCenterTestTask.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpertCenterTestTask.Controllers
{
	[ApiController]
	[Route("/api/item/")]
	public class ItemController : ControllerBase
	{
		private readonly ItemCrud _ItemCrud;

		public ItemController(ItemCrud atemCrud)
		{
			_ItemCrud = atemCrud;
		}

		[HttpPost]
		[Route("additem")]
		async public Task<Item> Additems(Item item)
		{
			return await _ItemCrud.AddItemAsync(item);
		}

		[HttpDelete]
		[Route("deleteitem")]
		async public Task<Item> DeleteItem(int id)
		{
			return await _ItemCrud.DeleteItemAsync(id);
		}
	}
}
