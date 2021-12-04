using OrionProject.Core.Common;

namespace OrionProject.Core.Models
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public int IdClient { get; set; }
        public virtual Client Client { get; set; }
    }
}
