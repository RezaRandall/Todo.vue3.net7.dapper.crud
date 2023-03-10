using Microsoft.AspNetCore.Mvc;

namespace API.Dot7.CRUD.Controllers
{
    public class BeachController : Controller
    {
        [ApiController]
        [Route("[controller]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
