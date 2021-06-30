namespace Core.Entities
{
    public class Company //: BaseEntity
    {
        public int Id {get;set;}
        public string Name { get; set; }
       // public Exchange Exchange { get; set; }
        public string Ticker { get; set; }
        public string ISIN { get; set; }
        public string Website { get; set; }
    }
}