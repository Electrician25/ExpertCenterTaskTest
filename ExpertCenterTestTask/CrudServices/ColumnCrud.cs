using ExpertCenterTestTask.Data;
using ExpertCenterTestTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTestTask.CrudServices
{
	public class ColumnCrud
	{
		private readonly ApplicationContext _ApplicationContest;

		public ColumnCrud(ApplicationContext applicationContest)
		{
			_ApplicationContest = applicationContest;
		}

		async public Task<Column> GetColumnById(int id)
		{
			var columnId = await _ApplicationContest.Columns.FirstOrDefaultAsync(i => i.Id == id)
				?? throw new Exception();

			return columnId;
		}

		public Column[] GetAllPriceListColumn(string currecntColumnCount)
		{
			var toInt = int.Parse(currecntColumnCount);

			var columnCount = _ApplicationContest.Columns.Count();

			var resultColumns = new Column[toInt];

			for (int i = 0; i < toInt; i++)
			{
				resultColumns[i] = _ApplicationContest.Columns.FirstOrDefault(_ => _.Id == columnCount)
					?? throw new Exception();
				columnCount--;
			}

			return resultColumns;
		}

		async public Task<Column> AddNewColumnAsync(Column column)
		{
			await _ApplicationContest.Columns.AddAsync(column);

			if (column is null)
				throw new Exception();

			_ApplicationContest.SaveChanges();

			return column;
		}
	}
}