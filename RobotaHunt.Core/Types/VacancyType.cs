using GraphQL.Types;
using RobotaHunt.Core.Models;

namespace RobotaHunt.Core.Types
{
    public class VacancyType : ObjectGraphType<Vacancy>
    {
        public VacancyType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Description);
            Field(x => x.CompanyId);
            Field(x => x.Company);
        }
    }
}