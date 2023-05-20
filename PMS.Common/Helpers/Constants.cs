using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Common.Helpers
{
    /// <summary>
    /// The Constants Class
    /// </summary>
    public static class Constants
    {
        #region Routes

        /// <summary>
        /// Gets the User By Id Route
        /// </summary>
        public const string GetUserById = "GetUserById";

        /// <summary>
        /// Gets the list of all users Route
        /// </summary>
        public const string GetAllUsers = "GetAllUsers";

        /// <summary>
        /// Adds a new User Route
        /// </summary>
        public const string AddNewUser = "AddNewUser";

        /// <summary>
        /// Updates the User Details by Id Route
        /// </summary>
        public const string UpdateUserById = "UpdateUserById";

        /// <summary>
        /// Deletes the User by Id Route
        /// </summary>
        public const string DeleteUserById = "DeleteUserById";

        #endregion
    }
}
