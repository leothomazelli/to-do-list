﻿using WEB_API.Models;

namespace WEB_API.Services.UserService
{
    public interface IUserService
    {
        /// <summary>
        /// Create a new user based on the object received.
        /// </summary>
        /// <param name="user">The user who's going to be added by the object received.</param>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<User> Add(User user);

        /// <summary>
        /// Update/edit a user based on the object received.
        /// </summary>
        /// <param name="user">The user who's going to be edited by the object received.</param>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<User> Update(User user);

        /// <summary>
        /// Delete a user based on the id received.
        /// </summary>
        /// <param name="id">The user who's going to be deleted by the id received.</param>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<User> Delete(int id);

        /// <summary>
        /// Get all users registered in the database.
        /// </summary>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<IList<User>> GetAll();

        /// <summary>
        /// Get a user based on the id received.
        /// </summary>
        /// <param name="id">The user who's going to be returned by the id received.</param>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<User> GetUserById(int id);

        /// <summary>
        /// Used to login into the application.
        /// </summary>
        /// <param name="user">The user who's going to be logged by the object received.</param>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<User> Login(User user);

        /// <summary>
        /// Used to logout from the application
        /// </summary>
        /// <returns>Return a serviceResponse with the result for the operation.</returns>
        ServiceResponse<User> Logout();
    }
}
