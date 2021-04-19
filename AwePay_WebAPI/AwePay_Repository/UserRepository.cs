using AwePay_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwePay_Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AwePayContext _awePayContext;

		public UserRepository(AwePayContext awePayContext)
		{
			_awePayContext = awePayContext;
		}

		/// <summary>
		/// Create a new User
		/// </summary>
		public long CreateUser(UserData newUser)
		{
			_awePayContext.Add(newUser);
			_awePayContext.SaveChanges();
			return newUser.ID;
		}
		
		/// <summary>
		/// Update the User
		/// </summary>
		public long UpdateUser(int userId, UserData updateUser)
		{
			var existingUser = _awePayContext.UserData.Find(userId);
			if (existingUser != null)
			{
				existingUser.FullName = updateUser.FullName;
				existingUser.Email = updateUser.Email;
				existingUser.PhoneNo = updateUser.PhoneNo;
				existingUser.Age = updateUser.Age;
				_awePayContext.SaveChanges();
				return existingUser.ID;
			}
			else
				return 0;
		}

		/// <summary>
		/// Delete the user based on id
		/// </summary>
		public bool DeleteUser(int userId)
		{
			var user = _awePayContext.UserData.Where(u => u.ID == userId).FirstOrDefault();
			if (user != null)
			{
				_awePayContext.UserData.Remove(user);
				_awePayContext.SaveChanges();
				return true;
			}
			else
				return false;
		}

		/// <summary>
		/// Search and cache user based on keyword
		/// </summary>
		public List<UserData> SearchUser(bool email, bool phone, string keyword)
		{
			if (email && !phone)
			{
				return _awePayContext.UserData.Where(x => x.Email == keyword.Trim()).OrderBy(x => x.Email).ToList();
			}
			else if (!email && phone)
			{
				return _awePayContext.UserData.Where(x => x.PhoneNo == keyword.Trim()).OrderBy(x => x.PhoneNo).ToList();
			}
			else if (email && phone)
			{
				return _awePayContext.UserData.Where(x => x.Email == keyword.Trim() || x.PhoneNo == keyword.Trim()).OrderBy(x => x.FullName).ToList();
			}
			else
				return null;
		}

		/// <summary>
		/// Check duplicate user based email id
		/// </summary>
		/// <param name="emailId"></param>
		/// <returns></returns>
		public bool CheckDuplicateUser(string emailId)
		{
			return _awePayContext.UserData.Any(x => x.Email.ToLower() == emailId.ToLower());
		}
	}
}
