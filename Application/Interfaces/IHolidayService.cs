using Domain;

namespace Application.Interfaces;

public interface IHolidayService
{
	Task<List<Day>> GetHolidaysAsync();
}
