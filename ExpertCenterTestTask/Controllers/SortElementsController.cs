using ExpertCenterTestTask.Data;
using ExpertCenterTestTask.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpertCenterTestTask.Controllers
{
	[ApiController]
	[Route("/api/")]
	public class SortElementsController : ControllerBase
	{
		private readonly ApplicationContext _ApplicationContext;

		public SortElementsController(ApplicationContext applicationContext)
		{
			_ApplicationContext = applicationContext;
		}

		[HttpGet]
		[Route("sortdefcolumns")]
		public Column[] SortDefColumn([FromQuery] string orderSort)
		{
			var columns = from s in _ApplicationContext.Columns select s;

			switch (orderSort)
			{
				case "bynamedasc":
					columns = _ApplicationContext.Columns.OrderByDescending(s => s.Name);
					break;
				case "byiddasc":
					columns = _ApplicationContext.Columns.OrderByDescending(s => s.Id);
					break;
			}

			return columns.ToArray();
		}

		[HttpGet]
		[Route("sortcustomcolumns")]
		public ColumnData[] SortCustomColumn([FromQuery] string orderSort)
		{
			var columns = from s in _ApplicationContext.ColumnDatas select s;

			switch (orderSort)
			{
				case "byidasc":
					columns = _ApplicationContext.ColumnDatas
						.OrderBy(s => s.Id);
					break;
				case "byiddesc":
					columns = _ApplicationContext.ColumnDatas
						.OrderByDescending(s => s.Id);
					break;

				case "bycountasc":
					columns = _ApplicationContext.ColumnDatas
						.OrderBy(s => s.NumberValue);
					break;
				case "bycountdedesc":
					columns = _ApplicationContext.ColumnDatas
						.OrderByDescending(s => s.NumberValue);
					break;

				case "bytextvalueasc":
					columns = _ApplicationContext.ColumnDatas
						.OrderBy(s => s.TextValue);
					break;
				case "bytextvaluedesk":
					columns = _ApplicationContext.ColumnDatas
						.OrderByDescending(s => s.TextValue);
					break;

				case "bybooleanasc":
					columns = _ApplicationContext.ColumnDatas
						.OrderBy(s => s.BooleanValue);
					break;
				case "bybooleandesc":
					columns = _ApplicationContext.ColumnDatas
						.OrderByDescending(s => s.BooleanValue);
					break;

				case "bycolumnidasc":
					columns = _ApplicationContext.ColumnDatas
						.OrderBy(s => s.ColumnId);
					break;
				case "bycolumniddesc":
					columns = _ApplicationContext.ColumnDatas
						.OrderByDescending(s => s.ColumnId);
					break;

				case "byitemidasc":
					columns = _ApplicationContext.ColumnDatas
						.OrderBy(s => s.ItemId);
					break;
				case "byitemiddesc":
					columns = _ApplicationContext.ColumnDatas
						.OrderByDescending(s => s.ItemId);
					break;
			}

			return columns.ToArray();
		}
	}
}