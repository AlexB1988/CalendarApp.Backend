using System.ComponentModel;

namespace Domain;

public enum TypeOfDay
{
	[Description("Рабочий день")]
	WorkingDay = 1,

	[Description("Выходной день")]
	DayOff = 2,

	[Description("Государственный праздник")]
	Holiday = 3,

	[Description("Перенесенный(выходной)")]
	Rescheduled = 4
}
