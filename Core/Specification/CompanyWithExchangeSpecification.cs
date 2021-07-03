using Core.Entities;

namespace Core.Specification
{
    public class CompanyWithExchangeSpecification : BaseSpecification<Company>
    {
        public CompanyWithExchangeSpecification()
        {
            //AddInclude(x => x.Exchange);
        }

        public CompanyWithExchangeSpecification(int id) : base(x => x.Id == id)
        {
            //AddInclude(x => x.Exchange);
        }

        public CompanyWithExchangeSpecification(string isin) : base(x => x.ISIN == isin)
        {
            //AddInclude(x => x.Exchange);
        }
    }
}
