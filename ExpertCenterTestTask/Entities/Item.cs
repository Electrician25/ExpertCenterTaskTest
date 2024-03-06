using System.ComponentModel.DataAnnotations.Schema;

namespace ExpertCenterTestTask.Entities;

public class Item
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public int VendorCode { get; set; }

	[NotMapped]
	public IEnumerable<ColumnData>? ColumnData { get; set; }

	public int PriceListId { get; set; }
	public PriceList PriceList { get; set; } = null!;
}