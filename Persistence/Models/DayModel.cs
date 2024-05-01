using Domain;
using MongoDB.Bson;

namespace Persistence.Models;

public class DayModel : Day
{
	public ObjectId Id { get; set; }
}
