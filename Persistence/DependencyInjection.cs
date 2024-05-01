using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Services;

namespace Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSingleton( _ => new CalendarContext(configuration.GetConnectionString("Db") ?? throw new Exception("Connectionstring is lost")));
		services.AddScoped<IHolidayService, HolidayService>();

		return services;
	}
}
