using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
	public class TripService
	{
		private readonly IUserRetriever _userRetriever;
		private readonly ITripRepository _tripRepository;

		public TripService(IUserRetriever userRetriever, ITripRepository tripRepository)
		{
			_userRetriever = userRetriever;
			_tripRepository = tripRepository;
		}

		public List<Trip> GetTripsByUser(User friend)
		{
			var loggedInUser = _userRetriever.GetLoggedInUser();
			if (loggedInUser == null)
			{
				throw new UserNotLoggedInException();
			}

			return AreFriends(friend, loggedInUser)
				? _tripRepository.GetTripsFor(friend)
				: new List<Trip>();
		}

		private static bool AreFriends(User friend, User loggedUser)
		{
			return Enumerable.Contains(friend.GetFriends(), loggedUser);
		}
	}
}
