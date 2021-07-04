using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Exchange { get; set; }
        [Required]
        public string Ticker { get; set; }
        [Required]
        [RegularExpression("^[A-Z]{2}([A - Z0 - 9]){9}[0-9]$", 
            ErrorMessage = "ISIN should be a 12-character alphanumeric code with the first two characters must be letters / non numeric.")]
        public string ISIN { get; set; }
        public string WebSite { get; set; }
    }
}
