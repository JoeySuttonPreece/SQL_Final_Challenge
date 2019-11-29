using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sale = new HashSet<Sale>();
        }

        public int CustomerNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string InterestCode { get; set; }

        public Interest InterestCodeNavigation { get; set; }
        public ICollection<Sale> Sale { get; set; }
    }
}
