using PMS.Common.DTO;

namespace PMS.Business.Contracts
{
    /// <summary>
    /// The User Business Manager Interface
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Gets the User Details By ID
        /// </summary>
        /// <param name="userId">The User ID</param>
        /// <returns>The User Details</returns>
        Task<UserDTO> GetUserByIdAsync(int userId);

        /// <summary>
        /// Gets the List of All Users
        /// </summary>
        /// <returns>The List of User DTO</returns>
        Task<List<UserDTO>> GetAllUsersAsync();

        /// <summary>
        /// Adds a new User
        /// </summary>
        /// <param name="userDetails">The User Details DTO</param>
        /// <returns>The User ID</returns>
        Task<int> AddNewUserAsync(UserDTO userDetails);

        /// <summary>
        /// Updates the User Details based on the User ID
        /// </summary>
        /// <param name="userDetails">The User Details DTO</param>
        /// <returns>A boolean of success or failure</returns>
        Task<bool> UpdateUserByIdAsync(UserDTO userDetails);

        /// <summary>
        /// Deletes the user details for the user Id
        /// </summary>
        /// <param name="userId">The User Id to be deleted</param>
        /// <returns>A boolean of success or failure</returns>
        Task<bool> DeleteUserByIdAsync(int userId);
    }
}
