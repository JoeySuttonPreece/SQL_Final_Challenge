using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Sale
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int CustomerNumber { get; set; }
        public string RecordId { get; set; }

        public Customer CustomerNumberNavigation { get; set; }
        public Record Record { get; set; }
    }
}
