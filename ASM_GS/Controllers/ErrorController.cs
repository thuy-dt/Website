using Microsoft.AspNetCore.Mvc;

namespace ASM_GS.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("Error/404")]
        public IActionResult NotFound()
        {
            return View();
        }

        [HttpGet]
        [Route("Forbidden")]
        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
    }
}
