namespace ExpertCenterTestTask.Entities;

public class Column
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public CustomColumnKind Kind { get; set; }
}