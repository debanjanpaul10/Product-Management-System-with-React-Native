
namespace PMS.Common.Entities
{
    /// <summary>
    /// The Product Entity Class
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The Product Name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The Product GUID
        /// </summary>
        public Guid ProductGuid { get; set; }

        /// <summary>
        /// The Price of the Product
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// The IsActive flag
        /// </summary>
        public bool IsActive { get; set; }
    }
}
