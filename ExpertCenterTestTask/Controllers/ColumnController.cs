using ExpertCenterTestTask.CrudServices;
using ExpertCenterTestTask.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpertCenterTestTask.Controllers
{
	[ApiController]
	[Route("/api/")]
	public class ColumnController : ControllerBase
	{
		private readonly ColumnCrud _columnCrud;

		public ColumnController(ColumnCrud columnCrud)
		{
			_columnCrud = columnCrud;
		}

		[HttpGet]
		[Route("get/{id}")]
		async public Task<Column> GetColumn(int id)
		{
			return await _columnCrud.GetColumnByIdAsync(id);
		}

		[HttpPost]
		[Route("post")]
		async public Task<Column> AddColumn(Column column)
		{
			return await _columnCrud.AddNewColumnAsync(column);
		}

		[HttpGet]
		[Route("currentcolumns")]
		public Column[] AddColumn1([FromQuery] string count)
		{
			return _columnCrud.GetAllPriceListColumnsAsync(count);
		}
	}
}