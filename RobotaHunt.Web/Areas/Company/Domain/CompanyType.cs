using GraphQL.Types;

namespace RobotaHunt
{
    public class CompanyType : ObjectGraphType<Company>
    {
        public CompanyType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.VacanciesCount);
        }
    }
}