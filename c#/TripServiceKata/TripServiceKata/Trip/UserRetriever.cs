
namespace TripServiceKata.Trip
{
	public interface IUserRetriever
	{
		User GetLoggedInUser();
	}

	public class UserRetriever : IUserRetriever
	{
		public User GetLoggedInUser()
		{
			return UserNS.UserSession.GetInstance().GetLoggedUser();
		}
	}
}