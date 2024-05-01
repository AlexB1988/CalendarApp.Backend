using Application.Extensions;
using Application.Interfaces;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.UseCases;

public class DateRangeQuery : IRequest<IReadOnlyCollection<DateRangeViewModel>>
{
	public DateTime DateBegin { get; set; }

	public DateTime DateEnd { get; set; }

	private class Handler : IRequestHandler<DateRangeQuery, IReadOnlyCollection<DateRangeViewModel>>
	{
		private readonly IHolidayService _holidayService;

		public Handler(IHolidayService holidayService) =>
			_holidayService = holidayService;

		public async Task<IReadOnlyCollection<DateRangeViewModel>> Handle(DateRangeQuery request, CancellationToken cancellationToken)
		{
			var holidays = await _holidayService.GetHolidaysAsync();

			var holidayDict = holidays
				.GroupBy(x => x.Date)
				.ToDictionary(x => x.Key, x => x.FirstOrDefault());

			var rescheduledDateDict = holidays
				.Where(x => !string.IsNullOrEmpty(x.RescheduledDate))
				.GroupBy(x => x.RescheduledDate)
				.ToDictionary(x => x.Key, x => x.FirstOrDefault());

			var dateRange = new List<DateRangeViewModel>();

			var culture = new CultureInfo("ru-RU");

			var dateBegin = request.DateBegin;

			do
			{
				var date = dateBegin.ToString("dd.MM.yyyy");

				if (holidayDict.ContainsKey(date))
				{
					dateRange.Add(
						new DateRangeViewModel
						{
							Date = date,
							TypeOfDay = holidayDict[date].Type.GetDescription(),
							Holiday = holidayDict[date].HolidayName.GetDescription(),
							WeekDay = culture.DateTimeFormat.GetDayName(dateBegin.DayOfWeek),
							WorkingHours = 0
						});
				}
				else if (rescheduledDateDict.ContainsKey(date))
				{
					dateRange.Add(
						new DateRangeViewModel
						{
							Date = date,
							TypeOfDay = TypeOfDay.WorkingDay.GetDescription(),
							Holiday = Holiday.None.GetDescription(),
							WeekDay = culture.DateTimeFormat.GetDayName(dateBegin.DayOfWeek),
							WorkingHours = 7
						}
						);
				}
				else if (dateBegin.DayOfWeek == DayOfWeek.Sunday
					|| dateBegin.DayOfWeek == DayOfWeek.Saturday)
				{
					dateRange.Add(
						new DateRangeViewModel
						{
							Date = date,
							TypeOfDay = TypeOfDay.DayOff.GetDescription(),
							Holiday = Holiday.None.GetDescription(),
							WeekDay = culture.DateTimeFormat.GetDayName(dateBegin.DayOfWeek),
						});
				}
				else
				{
					dateRange.Add(
						new DateRangeViewModel
						{
							Date = date,
							TypeOfDay = TypeOfDay.WorkingDay.GetDescription(),
							Holiday = Holiday.None.GetDescription(),
							WeekDay = culture.DateTimeFormat.GetDayName(dateBegin.DayOfWeek),
						});
				}

				dateBegin = dateBegin.AddDays(1);
			}
			while (dateBegin <= request.DateEnd);

			return dateRange;
		}
	}
}
