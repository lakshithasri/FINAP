namespace FINAP.Domain
{
    public class BaseEntity
    {
        public int numCreatedBy { get; set; }
        public DateTime? dtCreatedDate { get; set; }
        public int numUpdatedBy { get; set; }
        public DateTime? dtUpdatedDate { get; set; }
        public bool bitActive { get; set; }
    }
}