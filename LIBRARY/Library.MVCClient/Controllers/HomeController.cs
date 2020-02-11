using System.Web.Mvc;

namespace Library.MVCClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Contacts()
        {
            return View();
        }
    }
}