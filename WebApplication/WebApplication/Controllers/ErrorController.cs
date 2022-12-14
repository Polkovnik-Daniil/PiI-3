using System.Web.Mvc;

namespace WebApplication.Controllers {
    public class ErrorController : Controller {
        // GET: Error
        public ActionResult Error() {
            Response.StatusCode = 404;
            ViewBag.url = Request.RawUrl;
            ViewBag.method = Request.HttpMethod;
            return View();
        }
    }
}