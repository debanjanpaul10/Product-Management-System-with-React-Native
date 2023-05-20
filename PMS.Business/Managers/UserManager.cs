using System.Net;
using PMS.Business.Contracts;
using PMS.Common.DTO;
using PMS.Data.Contracts;

namespace PMS.Business.Managers
{
    /// <summary>
    /// The User Business Manager class
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// The User Data Manager
        /// </summary>
        private readonly IUserDataManager userDataManager;

        /// <summary>
        /// Create a new instance of <see cref="UserManager"/> class
        /// </summary>
        /// <param name="userDataManager">The User Data Manager</param>
        public UserManager(IUserDataManager userDataManager)
        {
            this.userDataManager = userDataManager;
        }

        /// <summary>
        /// Gets the User Details by Id
        /// </summary>
        /// <param name="userId">The User Id</param>
        /// <returns>The User Details</returns>
        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            if (userId != 0)
            {
                var result = await this.userDataManager.GetUserByIdAsync(userId).ConfigureAwait(false);
                if (result != null)
                {
                    return result;
                }
            }

            return new UserDTO();
        }

        /// <summary>
        /// Gets the List of All Users
        /// </summary>
        /// <returns>The List of User DTO</returns>
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var result = await this.userDataManager.GetAllUsersAsync().ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Adds a new User
        /// </summary>
        /// <param name="userDetails">The User Details DTO</param>
        /// <returns>The Response DTO</returns>
        public async Task<int> AddNewUserAsync(UserDTO userDetails)
        {
            if (userDetails != null)
            {
                return await this.userDataManager.AddNewUserAsync(userDetails).ConfigureAwait(false);
            }

            return 0;
        }

        /// <summary>
        /// Updates the User Details based on the User ID
        /// </summary>
        /// <param name="userDetails">The User Details DTO</param>
        /// <returns>A boolean of success or failure</returns>
        public async Task<bool> UpdateUserByIdAsync(UserDTO userDetails)
        {
            if (userDetails != null)
            {
                return await this.userDataManager.UpdateUserByIdAsync(userDetails).ConfigureAwait(false);
            }

            return false;
        }

        /// <summary>
        /// Deletes the user details for the user Id
        /// </summary>
        /// <param name="userId">The User Id to be deleted</param>
        /// <returns>A boolean of success or failure</returns>
        public async Task<bool> DeleteUserByIdAsync(int userId)
        {
            if (userId != 0)
            {
                return await this.userDataManager.DeleteUserByIdAsync(userId).ConfigureAwait(false);
            }

            return false;
        }
    }
}
