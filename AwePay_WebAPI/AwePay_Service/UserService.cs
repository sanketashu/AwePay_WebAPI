using AwePay_DataAccess;
using AwePay_Repository;
using AwePay_Service.DTO;
using System;
using System.Collections.Generic;

namespace AwePay_Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly ICacheManager _cacheManager;

		public UserService(IUserRepository userRepository, ICacheManager cacheManager)
		{
			_userRepository = userRepository;
			_cacheManager = cacheManager;
		}
		public long CreateUser(UserData newUser)
		{
			UserData user = new UserData();
			user.FullName = newUser.FullName;
			user.Email = newUser.Email;
			user.PhoneNo = newUser.PhoneNo;
			user.Age = newUser.Age;
			if (!string.IsNullOrEmpty(newUser.FullName.Trim()) && !string.IsNullOrEmpty(newUser.Email.Trim()))
			{
				if (_userRepository.CheckDuplicateUser(user.Email))
					return -1; //Duplicate Email
				else
					return _userRepository.CreateUser(user); //Create user
			}
			else
				return -2; //Invalid Input
		}

		public long UpdateUser(int userId, UserData updateUser)
		{
			if (!string.IsNullOrEmpty(updateUser.FullName.Trim()) && !string.IsNullOrEmpty(updateUser.Email.Trim()))
			{
				return _userRepository.UpdateUser(userId, updateUser); //Update user
			}
			else
				return -2; //Invalid Input
		}

		public bool DeleteUSer(int userId)
		{
			return _userRepository.DeleteUser(userId);
		}

		public List<UserData> SearchUser(bool email, bool phone, string keyword)
		{
			List<UserData> listUsers;

			string CacheKeyName = CacheKeys.Users + "Search_" + keyword;
			var cachedData = _cacheManager.GetCache(CacheKeyName);
			if (cachedData == null)
			{
				listUsers = _userRepository.SearchUser(email, phone, keyword);
				CacheRequest cache = new CacheRequest
				{
					key = CacheKeyName,
					value = listUsers
				};

				_cacheManager.SetCache(cache);

				return listUsers;
			}
			else
				return cachedData;
		}
	}
}
