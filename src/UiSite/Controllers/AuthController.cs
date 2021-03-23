using Microsoft.AspNetCore.Mvc;

namespace UiSite.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult FirebaseAuthentication()
        {
            return View();
        }

    }
}
