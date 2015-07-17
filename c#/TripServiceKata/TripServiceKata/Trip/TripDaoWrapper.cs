using System.Collections.Generic;

namespace TripServiceKata.Trip
{
	public interface ITripDao
	{
		List<Trip> GetTripsFor(User user);
	}

	public class TripDaoWrapper : ITripDao
	{
		public List<Trip> GetTripsFor(User user)
		{
			return TripDAO.FindTripsByUser(user);
		}
	}
}