using Core.Entities;

namespace Core.Specification
{
    public class UseSpecification : BaseSpecification<AppUser>
    {
        public UseSpecification()
        {
            //AddInclude(x => x.UserName);
        }

        public UseSpecification(string id) : base(x => x.UserName == id)
        {
            //AddInclude(x => x.UserName);
        }
    }
}
