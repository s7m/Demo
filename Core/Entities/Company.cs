namespace Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string Ticker { get; set; }
        public string ISIN { get; set; }
        public string Website { get; set; }
    }
}