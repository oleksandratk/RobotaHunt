using System.Linq;
using HotChocolate;
using RobotaHunt.Core.Models;

namespace RobotaHunt.Core.Data
{
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {
        
        [GraphQLDescription("Gets the queryable companies.")]
        public IQueryable<Company> GetCompanies([Service] RobotaHuntDbContext context)
        {
            return context.Companies;
        }
        
        [GraphQLDescription("Gets the queryable vacancies.")]
        public IQueryable<Vacancy> GetVacancies([Service] RobotaHuntDbContext context)
        {
            return context.Vacancies;
        }
        
        [GraphQLDescription("Gets the queryable vacancies by page.")]
        public IQueryable<Vacancy> GetPartOfVacancies([Service] RobotaHuntDbContext context, int page, int pageSize)
        {
            return context.Vacancies.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}