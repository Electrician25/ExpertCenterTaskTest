using ExpertCenterTestTask.Data;
using ExpertCenterTestTask.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTestTask.CrudServices
{
	public class ColumnDataCrud : ControllerBase
	{
		private readonly ApplicationContext _applicationContext;

		public ColumnDataCrud(ApplicationContext applicationContext)
		{
			_applicationContext = applicationContext;
		}

		async public Task<ColumnData> GetCustomColumnByIdAsync(int id)
		{
			return await _applicationContext.ColumnDatas.FirstOrDefaultAsync(c => c.Id == id)
				?? throw new Exception();
		}

		async public Task<ColumnData[]> GetAllCustomColumn()
		{
			return await _applicationContext.ColumnDatas.ToArrayAsync();
		}

		async public Task<ColumnData> AddNewCustomColumn(ColumnData columnData)
		{
			if (columnData is null)
			{
				throw new Exception();
			}

			await _applicationContext.ColumnDatas.AddAsync(columnData);
			_applicationContext.SaveChanges();

			return columnData;
		}

		public async Task<ColumnData> DeleteCustomColumn(int id)
		{
			var columnId = await _applicationContext.ColumnDatas.FindAsync(id)
				?? throw new Exception();

			_applicationContext.Remove(columnId);
			_applicationContext.SaveChanges();

			return columnId;
		}
	}
}