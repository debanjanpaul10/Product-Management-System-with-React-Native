
using System.Net;

namespace PMS.Common.DTO
{
    /// <summary>
    /// The Response DTO
    /// </summary>
    public class ResponseDTO
    {
        /// <summary>
        /// The Data to be sent as response
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// The boolean for success / failure
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// The Response Code
        /// </summary>
        public HttpStatusCode ResponseCode { get; set; }
    }
}
