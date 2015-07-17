using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
	public class TripService
	{
		private readonly IUserRetriever _userRetriever;
		private readonly ITripDao _tripDaoWrapper;

		public TripService(IUserRetriever userRetriever, ITripDao tripDao)
		{
			_userRetriever = userRetriever;
			_tripDaoWrapper = tripDao;
		}

		public List<Trip> GetTripsByUser(User friend)
		{
			var loggedUser = GetLoggedUser();
			if (loggedUser == null)
			{
				throw new UserNotLoggedInException();
			}

			return Enumerable.Contains(friend.GetFriends(), loggedUser) 
				? _tripDaoWrapper.GetTripsFor(friend)
				: new List<Trip>();
		}

		private User GetLoggedUser()
		{
			return _userRetriever.GetLoggedUser();
		}
	}
}
