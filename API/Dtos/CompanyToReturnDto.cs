namespace API.Dtos
{
    public class CompanyToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }
        public int ExchangeId { get; set; }
        public string Ticker { get; set; }
        public string ISIN { get; set; }
        public string WebSite { get; set; }
    }
}
