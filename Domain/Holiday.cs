using System.ComponentModel;

namespace Domain;

public enum Holiday
{
	[Description("Обычный день")]
	None = 0,

	[Description("Новый год")]
	NewYear = 1,

	[Description("Рождество Христово")]
	Christmas = 2,

	[Description("День защитника Отечества")]
	DefenderDay = 3,

	[Description("Международный женский день")]
	WomanDay = 4,

	[Description("Праздник Весны и Труда")]
	SpringDay = 5,

	[Description("День Победы")]
	VictoryDay = 6,

	[Description("День России")]
	RussiaDay = 7,

	[Description("День народного единства")]
	Uniteday = 8
}
