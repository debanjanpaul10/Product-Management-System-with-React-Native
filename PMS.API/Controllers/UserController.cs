using System.Net;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Mvc;
using PMS.Business.Contracts;
using PMS.Common.DTO;
using PMS.Common.Helpers;

namespace PMS.API.Controllers
{
    /// <summary>
    /// The User Controller Class
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The Telemetry Client
        /// </summary>
        private readonly TelemetryClient telemetryClient;

        /// <summary>
        /// The User Business Manager
        /// </summary>
        private readonly IUserManager userManager;

        /// <summary>
        /// Creates a new instance of <see cref="UserController"/> class
        /// </summary>
        /// <param name="teleConfiguration">The Teleconfiguration</param>
        /// <param name="userManager">The User Business Manager</param>
        public UserController(TelemetryConfiguration teleConfiguration, IUserManager userManager)
        {
            this.telemetryClient = new TelemetryClient(teleConfiguration);
            this.userManager = userManager;
        }

        /// <summary>
        /// Gets the User Details by ID
        /// </summary>
        /// <param name="userId">The User ID</param>
        /// <returns>The Response DTO</returns>
        [HttpGet]
        [Route(Constants.GetUserById)]
        public async Task<ResponseDTO> GetUserByIdAsync(int userId)
        {
            try
            {
                var result = await this.userManager.GetUserByIdAsync(userId).ConfigureAwait(false);
                return new ResponseDTO
                {
                    Data = result,
                    IsSuccess = true,
                    ResponseCode = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                var logMessage = new Dictionary<string, string> { { "ErrorMessage", $"Error in {nameof(GetUserByIdAsync)} for UserId: {userId}" } };
                this.telemetryClient.TrackException(e, logMessage);

                return new ResponseDTO()
                {
                    Data = e.Message,
                    IsSuccess = false,
                    ResponseCode = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Gets the List of All Users
        /// </summary>
        /// <returns>The Response DTO</returns>
        [HttpGet]
        [Route(Constants.GetAllUsers)]
        public async Task<ResponseDTO> GetAllUsersAsync()
        {
            try
            {
                var result = await this.userManager.GetAllUsersAsync().ConfigureAwait(false);
                return new ResponseDTO()
                {
                    Data = result,
                    IsSuccess = true,
                    ResponseCode = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                var logMessage = new Dictionary<string, string> { { "ErrorMessage", $"Error in {nameof(GetAllUsersAsync)}" } };
                this.telemetryClient.TrackException(e, logMessage);

                return new ResponseDTO()
                {
                    Data = e.Message,
                    IsSuccess = false,
                    ResponseCode = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Adds a new User with User Details
        /// </summary>
        /// <param name="userDetails">The User Details DTO</param>
        /// <returns>The Response DTO</returns>
        [HttpPost]
        [Route(Constants.AddNewUser)]
        public async Task<ResponseDTO> AddNewUserAsync(UserDTO userDetails)
        {
            try
            {
                var result = await this.userManager.AddNewUserAsync(userDetails).ConfigureAwait(false);
                return new ResponseDTO()
                {
                    Data = result,
                    IsSuccess = true,
                    ResponseCode = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                var logMessage = new Dictionary<string, string> { { "ErrorMessage", $"Error in {nameof(AddNewUserAsync)} for {userDetails.UserName}" } };
                this.telemetryClient.TrackException(e, logMessage);

                return new ResponseDTO()
                {
                    IsSuccess = false,
                    ResponseCode = HttpStatusCode.InternalServerError,
                    Data = e.Message
                };
            }
        }

        /// <summary>
        /// Updates the User Details with ID
        /// </summary>
        /// <param name="userDetails">The User Details</param>
        /// <returns>The Response DTO</returns>
        [HttpPut]
        [Route(Constants.UpdateUserById)]
        public async Task<ResponseDTO> UpdateUserByIdAsync(UserDTO userDetails)
        {
            try
            {
                var result = await this.userManager.UpdateUserByIdAsync(userDetails).ConfigureAwait(false);
                return new ResponseDTO()
                {
                    Data = result,
                    IsSuccess = true,
                    ResponseCode = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                var logMessage = new Dictionary<string, string> { { "ErrorMessage", $"Error in {nameof(UpdateUserByIdAsync)} for {userDetails.UserId}" } };
                this.telemetryClient.TrackException(e, logMessage);

                return new ResponseDTO()
                {
                    Data = e.Message,
                    IsSuccess = false,
                    ResponseCode = HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Deletes the User By User ID
        /// </summary>
        /// <param name="userId">The user Id</param>
        /// <returns>The Response DTO</returns>
        [HttpPut]
        [Route(Constants.DeleteUserById)]
        public async Task<ResponseDTO> DeleteUserByIdAsync(int userId)
        {
            try
            {
                var result = await this.userManager.DeleteUserByIdAsync(userId).ConfigureAwait(false);
                return new ResponseDTO()
                {
                    Data = result,
                    IsSuccess = true,
                    ResponseCode = HttpStatusCode.InternalServerError
                };
            }
            catch (Exception e)
            {
                var logMessage = new Dictionary<string, string> { { "ErrorMessage", $"Error in {nameof(DeleteUserByIdAsync)} for {userId}" } };
                this.telemetryClient.TrackException(e, logMessage);

                return new ResponseDTO()
                {
                    Data = e.Message,
                    IsSuccess = false,
                    ResponseCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
