using OrionProject.Core.Common;
using System;
using System.Collections.Generic;

namespace OrionProject.Core.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
