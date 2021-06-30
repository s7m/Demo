namespace Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public Exchange Exchange { get; set; }
        public int ExchangeId { get; set; }
        public string Ticker { get; set; }
        public string ISIN { get; set; }
        public string Website { get; set; }
    }
}