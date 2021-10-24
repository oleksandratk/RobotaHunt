using GraphQL.Types;

namespace RobotaHunt
{
    public class VacancyType : ObjectGraphType<Vacancy>
    {
        public VacancyType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Description);
            Field(x => x.Company);
        }
    }
}