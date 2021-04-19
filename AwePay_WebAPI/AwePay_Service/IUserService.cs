using AwePay_DataAccess;
using AwePay_Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwePay_Service
{
	public interface IUserService
	{
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        long CreateUser(UserData newUser);

        /// <summary>
        /// Update the existing user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        long UpdateUser(int userId, UserData updateUser);

        /// <summary>
        /// Delete the existing user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool DeleteUSer(int userId);

        /// <summary>
        /// Search the userand display based on the parameters
        /// </summary>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        List<UserData> SearchUser(bool email, bool phone,string keyword);
    }
}
