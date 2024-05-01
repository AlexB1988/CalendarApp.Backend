namespace Domain;

public class Day
{
	public string Date { get; set; } = string.Empty;

	public TypeOfDay Type { get; set; }

	public Holiday HolidayName { get; set; }

	public string RescheduledDate { get; set; } = string.Empty;
}
