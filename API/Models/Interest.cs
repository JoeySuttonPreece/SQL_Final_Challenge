using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Interest
    {
        public Interest()
        {
            Customer = new HashSet<Customer>();
        }

        public string InterestCode { get; set; }
        public string Description { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
