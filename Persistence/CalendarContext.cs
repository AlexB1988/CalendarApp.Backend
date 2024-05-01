using MongoDB.Driver;
using Persistence.Models;

namespace Persistence;

public class CalendarContext
{
	private readonly IMongoDatabase? _database;

	public CalendarContext(string connection)
	{
		var client = new MongoClient(connection);
		if (client != null)
			_database = client.GetDatabase("newdb");
	}

	public IMongoCollection<DayModel> HoliDays =>
			_database != null
				? _database.GetCollection<DayModel>("holidays")
				: throw new Exception("Not connected to the database");

}
