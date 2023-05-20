
namespace PMS.Common.Entities
{
    /// <summary>
    /// The User Entity Class
    /// </summary>
    public class User
    {
        /// <summary>
        /// The User ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The User Name 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The User Email Id
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// The Contact Number
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// The boolean for Active Result
        /// </summary>
        public bool IsActive { get; set; }
    }
}
