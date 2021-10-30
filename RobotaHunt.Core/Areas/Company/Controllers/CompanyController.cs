using Microsoft.AspNetCore.Mvc;
using RobotaHunt.Core.Controllers;
using RobotaHunt.Core.Models;

namespace RobotaHunt.Core
{
    public class CompanyController : ExplorerController<Company>
    {
        public override Company GetEntity()
        {
            throw new System.NotImplementedException();
        }

        public override Company PutEntity(Company entity)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Index()
        {
            return View("/Areas/Company/Views/Shared/CompaniesView.cshtml");
        }
    }
}