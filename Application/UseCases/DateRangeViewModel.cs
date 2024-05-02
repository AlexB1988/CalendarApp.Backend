namespace Application.UseCases;

public class DateRangeViewModel
{
	public string Date { get; set; } = string.Empty;

	public string RescheduledDay {  get; set; } = string.Empty;

	public string WeekDay { get; set; } = string.Empty;

	public string TypeOfDay {  get; set; } = string.Empty;

	public string Holiday { get; set; } = string.Empty;

	public int WorkingHours { get; set; }
}
