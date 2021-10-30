using Microsoft.AspNetCore.Mvc;
using RobotaHunt.Core.Controllers;
using RobotaHunt.Core.Models;

namespace RobotaHunt.Core
{
    public class VacancyController : ExplorerController<Vacancy>
    {
        public override Vacancy GetEntity()
        {
            throw new System.NotImplementedException();
        }

        public override Vacancy PutEntity(Vacancy entity)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Index()
        {
            throw new System.NotImplementedException();
        }
    }
}