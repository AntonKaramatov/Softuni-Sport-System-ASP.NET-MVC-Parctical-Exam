namespace SportSystem.Web.Controllers
{
    using SportSystem.Data;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        protected BaseController(ISportSystemData data)
        {
            this.Data = data;
        }

        protected ISportSystemData Data { get; private set; }
    }
}