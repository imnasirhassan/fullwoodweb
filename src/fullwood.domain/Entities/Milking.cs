namespace fullwood.domain.Entities
{
    public class Milking : BaseEntity
    {
        public int AnimalId { get; set; }
        public DateTime MilkingDate { get; set; }
        public int RobotId { get; set; }
        public bool EndOfMilkingStatus { get; set; }
    }
}
