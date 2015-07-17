
namespace TripServiceKata.Trip
{
	public interface IUserRetriever
	{
		User GetLoggedUser();
	}

	public class UserRetriever : IUserRetriever
	{
		public User GetLoggedUser()
		{
			return UserNS.UserSession.GetInstance().GetLoggedUser();
		}
	}
}