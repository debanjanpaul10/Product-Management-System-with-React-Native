using System.Net;
using PMS.Common.Entities;
using PMS.Data.Contracts;
using PMS.Data.Entities;
using PMS.Common.DTO;
using Microsoft.EntityFrameworkCore;

namespace PMS.Data.Managers
{
    /// <summary>
    /// The User Data Manager class
    /// </summary>
    public class UserDataManager : IUserDataManager
    {
        /// <summary>
        /// The PMS Database Context
        /// </summary>
        private readonly PmsdatabaseContext dbContext;

        /// <summary>
        /// Creates a new instance of <see cref="UserDataManager"/> class
        /// </summary>
        /// <param name="pmsDbContext">The PMS DB Context</param>
        public UserDataManager(PmsdatabaseContext pmsDbContext) : base()
        {
            this.dbContext = pmsDbContext;
        }

        /// <summary>
        /// Gets the User Details by ID
        /// </summary>
        /// <param name="userId">The User Id</param>
        /// <returns>The User Details</returns>
        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var userEntity = await this.dbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive).ConfigureAwait(false);
            if (userEntity != null)
            {
                return new UserDTO()
                {
                    UserId = userEntity.UserId,
                    UserName = userEntity.UserName,
                    EmailId = userEntity.EmailId,
                    ContactNumber = userEntity.ContactNumber,
                };
            }

            return new UserDTO();
        }

        /// <summary>
        /// Gets the List of All Users
        /// </summary>
        /// <returns>The List of User DTO</returns>
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var usersEntities = await this.dbContext.Users.Where(x => x.IsActive).Select(x => 
                new UserDTO
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    ContactNumber= x.ContactNumber,
                    EmailId = x.EmailId,
                }).ToListAsync();

            return usersEntities;
        }

        /// <summary>
        /// Adds a new User
        /// </summary>
        /// <param name="userDetails">The User Details DTO</param>
        /// <returns>The User ID</returns>
        public async Task<int> AddNewUserAsync(UserDTO userDetails)
        {
            var userEntity = new User
            {
                UserName = userDetails.UserName,
                ContactNumber = userDetails.ContactNumber,
                EmailId = userDetails.EmailId,
                IsActive = true
            };

            await this.dbContext.AddAsync(userEntity).ConfigureAwait(false);
            await this.dbContext.SaveChangesAsync().ConfigureAwait(false);

            return userDetails.UserId;
        }

        /// <summary>
        /// Updates the User Details based on the User ID
        /// </summary>
        /// <param name="userDetails">The User Details DTO</param>
        /// <returns>A boolean of success or failure</returns>
        public async Task<bool> UpdateUserByIdAsync(UserDTO userDetails)
        {
            var userEntity = await this.dbContext.Users.FirstOrDefaultAsync(x => x.UserId == userDetails.UserId && x.IsActive).ConfigureAwait(false);
            if (userEntity != null)
            {
                userEntity.UserName = userDetails.UserName;
                userEntity.ContactNumber = userDetails.ContactNumber;
                userEntity.EmailId = userDetails.EmailId;

                await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
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
            var userEntity = await this.dbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive).ConfigureAwait(false);
            if (userEntity != null)
            {
                this.dbContext.Users.Remove(userEntity);
                await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }

            return false;
        }
    }
}
