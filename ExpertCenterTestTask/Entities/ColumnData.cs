namespace ExpertCenterTestTask.Entities;

public class ColumnData
{
	public int Id { get; set; }
	public double? NumberValue { get; set; }
	public string? TextValue { get; set; } = null!;
	public bool? BooleanValue { get; set; }
	public int ColumnId { get; set; }
	public Column Column { get; set; } = null!;
	public int ItemId { get; set; }
	public Item Item { get; set; } = null!;
}