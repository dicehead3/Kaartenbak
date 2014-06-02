using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var filePath = Server.MapPath("~/app/views/main.html");
            if (System.IO.File.Exists(filePath))
            {
                return File(filePath, "text/html");
            }
            return View();
        }

    }
}
