using ExpertCenterTestTask.CrudServices;

namespace ExpertCenterTestTask.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddCategoryCrudServices(this IServiceCollection services)
		{
			services.AddTransient<PriceListsCrud>();
			services.AddTransient<ColumnDataCrud>();
			services.AddTransient<ColumnCrud>();
			services.AddTransient<ItemCrud>();

			return services;
		}
	}
}
