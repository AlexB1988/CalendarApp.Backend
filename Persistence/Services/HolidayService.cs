using Application.Interfaces;
using Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistence.Models;

namespace Persistence.Services;

public class HolidayService : IHolidayService
{
	private readonly CalendarContext _calendarContext;

	public HolidayService(CalendarContext calendarContext) =>
		_calendarContext = calendarContext;

	public async Task<List<Day>> GetHolidaysAsync()
	{
		var data = await _calendarContext.HoliDays
			.FindAsync<DayModel>(new BsonDocument());

		var holidays = await data.ToListAsync();

		var days = new List<Day>();

		holidays.ForEach(holiday =>
		{
			var day = new Day
			{
				Date = holiday.Date,
				Type = holiday.Type,
				HolidayName = holiday.HolidayName,
				RescheduledDate = holiday.RescheduledDate,
			};
			days.Add(day);
		});

		return days;
	}
}
