using GraphQL.Types;

namespace RobotaHunt.Core.Areas.Company
{
    public class CompanyType : ObjectGraphType<Models.Company>
    {
        public CompanyType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.VacanciesCount);
        }
    }
}