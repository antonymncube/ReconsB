using Microsoft.AspNetCore.Mvc;

namespace ReconsB.Controllers
{
    [Route("api/Controller")]
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
