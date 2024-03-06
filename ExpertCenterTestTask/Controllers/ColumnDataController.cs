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
		async public Task<ColumnData[]> GetAllCustomColumn()
		{
			return await _columnDataCrud.GetAllCustomColumn();
		}

		[HttpPost]
		[Route("add")]
		async public Task<ColumnData> AddCustomColumn(ColumnData columnData)
		{
			return await _columnDataCrud.AddNewCustomColumn(columnData);
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public async Task<ColumnData> DeleteCustomColumn(int id)
		{
			return await _columnDataCrud.DeleteCustomColumn(id);
		}
	}
}