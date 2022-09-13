using System;

namespace ProfileLearn.Entities
{
    public class HistoryEntitty
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDated { get; set; }  
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
