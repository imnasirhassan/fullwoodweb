namespace fullwood.domain.Entities
{
    public class Cow : BaseEntity
    {
        public bool OnFarm { get; set; }
        public int CowNumber { get; set; }
        public string CowName { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; }
    }
}
