using ExpertCenterTestTask.CrudServices;
using ExpertCenterTestTask.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpertCenterTestTask.Controllers
{
	[ApiController]
	[Route("/api/{controller}")]
	public class PriceListController : ControllerBase
	{
		private readonly PriceListsCrud _PriceListsCrud;

		public PriceListController(PriceListsCrud priceListsCrud)
		{
			_PriceListsCrud = priceListsCrud;
		}

		[HttpGet]
		[Route("getall")]
		async public Task<PriceList[]> GetAllPriceLists()
		{
			int page = 1;
			int pageSize = 6;
			var productsPerPage = _PriceListsCrud
				.GetAllPriceListsAsync().Result
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToArray();

			return productsPerPage;
		}

		[HttpGet]
		async public Task<PriceList> GetPriceListById(int id)
		{
			return await _PriceListsCrud.GetPriceListByIdAsync(id);
		}

		[HttpPost]
		[Route("add")]
		async public Task<PriceList> AddNewPriceList(PriceList list)
		{
			return await _PriceListsCrud.AddNewPriceListAsync(list);
		}
	}
}