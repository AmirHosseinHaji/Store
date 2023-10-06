using Store.Data;
using Store.Models;

namespace Store.Repository
{
	public interface IUserRepository
	{
		public bool IsExistedUserByEmail(string Email);
		
		User GetUserForLoggin(string Email, string Password);
	}
	public class UserRepository : IUserRepository
	{
		private readonly MyDBShopContext _db;
		public UserRepository(MyDBShopContext db)
		{
			_db = db;
		}
		
		public User GetUserForLoggin(string email, string password)
		{
			return _db.User.SingleOrDefault(c => c.Email == email && c.Password == password);
		}

		public bool IsExistedUserByEmail(string Email)
		{
			return _db.User.Any(c => c.Email == Email);
		}
	}
}
