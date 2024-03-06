using ExpertCenterTestTask.CrudServices;
using ExpertCenterTestTask.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpertCenterTestTask.Controllers
{
	[ApiController]
	[Route("/api/pagination/")]
	public class PaginationSystemController : ControllerBase
	{
		private readonly PriceListsCrud _priceListsCrud;

		public PaginationSystemController(PriceListsCrud priceListsCrud)
		{
			_priceListsCrud = priceListsCrud;
		}

		[HttpGet]
		[Route("pricelistpagin")]
		public async Task<PriceList[]> GetAllLists()
		{
			int page = 1;
			int pageSize = 6;
			var productsPerPage = _priceListsCrud
				.GetAllPriceListsAsync().Result
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToArray();

			return productsPerPage;
		}
	}
}
