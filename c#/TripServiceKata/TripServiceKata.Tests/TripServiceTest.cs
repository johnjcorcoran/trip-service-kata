using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
	public class TripServiceTest : IUserRetriever, ITripRepository
	{
		private User _loggedIUser;
		private TripService _tripService;
		private List<Trip.Trip> _trips;

		[SetUp]
		public void SetUp()
		{
			_tripService = new TripService(this, this);
		}

		[Test]
		public void Should_throw_when_user_is_not_logged_in()
		{
			_trips = Enumerable.Empty<Trip.Trip>().ToList();
			_loggedIUser = null;

			var friend = new User();
			Assert.Throws<UserNotLoggedInException>(() => _tripService.GetTripsByUser(friend));
		}

		[Test]
		public void Should_return_empty_trip_list_for_logged_in_user_with_no_friends()
		{
			_trips = Enumerable.Empty<Trip.Trip>().ToList();
			_loggedIUser = new User();

			var friend = new User();
			var trips = _tripService.GetTripsByUser(friend);
			Assert.IsEmpty(trips);
		}

		[Test]
		public void Should_return_empty_trip_list_for_logged_in_user_not_a_friend_match()
		{
			_trips = Enumerable.Empty<Trip.Trip>().ToList();
			_loggedIUser = new User();
			_loggedIUser.AddFriend(new User());

			var friend = new User();
			var trips = _tripService.GetTripsByUser(friend);

			Assert.IsEmpty(trips);
		}

		[Test]
		public void Should_return_friends_trips_when_logged_in_user_and_friend_are_friends()
		{
			_trips = new List<Trip.Trip>(){new Trip.Trip()};
			_loggedIUser = new User();
			var me = new User();
			me.AddFriend(_loggedIUser);

			var trips = _tripService.GetTripsByUser(me);

			Assert.That(trips, Is.EqualTo(_trips));

		}

		public User GetLoggedInUser()
		{
			return _loggedIUser;
		}

		public List<Trip.Trip> GetTripsFor(User user)
		{
			return _trips;
		}
	}
}
