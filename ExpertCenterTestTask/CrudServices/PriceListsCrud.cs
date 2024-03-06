using ExpertCenterTestTask.Data;
using ExpertCenterTestTask.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTestTask.CrudServices
{
	public class PriceListsCrud : ControllerBase
	{
		private readonly ApplicationContext _ApplicationContest;

		public PriceListsCrud(ApplicationContext applicationContest)
		{
			_ApplicationContest = applicationContest;
		}

		async public Task<PriceList[]> GetAllPriceListsAsync()
		{
			return await _ApplicationContest.PriceLists.ToArrayAsync();
		}

		async public Task<PriceList> GetPriceListByIdAsync(int id)
		{
			return await _ApplicationContest.PriceLists
				.FirstOrDefaultAsync(list => list.Id == id)
				?? throw new Exception();
		}

		async public Task<PriceList> AddNewPriceListAsync(PriceList priseList)
		{
			await _ApplicationContest.PriceLists.AddAsync(priseList);

			if (priseList is null)
				throw new Exception();

			_ApplicationContest.SaveChanges();

			return priseList;
		}
	}
}