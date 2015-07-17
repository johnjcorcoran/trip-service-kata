using System.Collections.Generic;

namespace TripServiceKata.Trip
{
	public interface ITripRepository
	{
		List<Trip> GetTripsFor(User user);
	}

	public class TripRepositoryWrapper : ITripRepository
	{
		public List<Trip> GetTripsFor(User user)
		{
			return TripDAO.FindTripsByUser(user);
		}
	}
}