using OrionProject.Core.Common;

namespace OrionProject.Core.DTOs
{
    public class AddressDTO : BaseEntity
    {
        public string City { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public int IdClient { get; set; }
    }
}
