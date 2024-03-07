using ExpertCenterTestTask.CrudServices;
using ExpertCenterTestTask.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpertCenterTestTask.Controllers
{
	[ApiController]
	[Route("/api/customcolumn/{controller}")]
	public class ColumnDataController : ControllerBase
	{
		private readonly ColumnDataCrud _columnDataCrud;

		public ColumnDataController(ColumnDataCrud columnDataCrud)
		{
			_columnDataCrud = columnDataCrud;
		}

		[HttpGet]
		[Route("byid/{id}")]
		async public Task<ColumnData> GetCustomColumnByid(int id)
		{
			return await _columnDataCrud.GetCustomColumnByIdAsync(id);
		}

		[HttpGet]
		[Route("getall")]
		async public Task<ColumnData[]> GetAllCustomColumns()
		{
			return await _columnDataCrud.GetAllCustomColumns();
		}

		[HttpPost]
		[Route("add")]
		async public Task<ColumnData> AddCustomColumn(ColumnData columnData)
		{
			return await _columnDataCrud.AddNewCustomColumnAsync(columnData);
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public async Task<ColumnData> DeleteCustomColumn(int id)
		{
			return await _columnDataCrud.DeleteCustomColumnAsync(id);
		}
	}
}