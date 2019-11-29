using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Record
    {
        public Record()
        {
            Sale = new HashSet<Sale>();
        }

        public string RecordId { get; set; }
        public string Name { get; set; }
        public string Performer { get; set; }

        public ICollection<Sale> Sale { get; set; }
    }
}
