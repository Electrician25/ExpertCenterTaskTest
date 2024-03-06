using System.ComponentModel.DataAnnotations.Schema;

namespace ExpertCenterTestTask.Entities;

public class PriceList
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	[NotMapped]
	public IEnumerable<Column>? Columns { get; set; }
	[NotMapped]
	public IEnumerable<Item>? Items { get; set; }
}