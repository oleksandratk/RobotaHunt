using Microsoft.AspNetCore.Mvc;

namespace RobotaHunt.Core.Controllers
{
    public abstract class ExplorerController<TEntity> : Controller
        where TEntity : class, new()
    {
        [HttpGet]
        public abstract TEntity GetEntity();

        [HttpPost]
        public abstract TEntity PutEntity(TEntity entity);
    }
}