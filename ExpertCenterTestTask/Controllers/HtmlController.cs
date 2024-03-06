using ExpertCenterTestTask.ActionResult;
using Microsoft.AspNetCore.Mvc;

namespace ExpertCenterTestTask.Controllers
{
	[Route("/api/{controller}")]
	[ApiController]
	public class HtmlController : ControllerBase
	{
		private readonly Func<string, HtmlResult> _htmlResult;

		public HtmlController(Func<string, HtmlResult> htmlResult)
		{
			_htmlResult = htmlResult;
		}

		[HttpGet]
		[Route("PriceList")]
		public IActionResult WriteLists()
		{
			return _htmlResult(@"./wwwroot/html/mainPage.html");
		}

		[HttpGet]
		[Route("PriceListCreate")]
		public IActionResult CreateLists()
		{
			return _htmlResult(@"./wwwroot/html/PriceListPages/createPriceListPage.html");
		}

		[HttpGet]
		[Route("AdditemPage")]
		public IActionResult AddItem()
		{
			return _htmlResult(@"./wwwroot/html/ItemPage/addItemPage.html");
		}

		[HttpGet]
		[Route("AddColumns")]
		public IActionResult GetColumnsInPriceList()
		{
			return _htmlResult(@"./wwwroot/html/ItemPage/addItemPage.html");
		}

		[HttpGet]
		[Route("AddItemPageLast")]
		public IActionResult AddItemList()
		{
			return _htmlResult(@"./wwwroot/html/addItemlistLast.html");
		}
	}
}