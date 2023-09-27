using ConcultancyCRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcultancyCRM.Controllers
{
    public class AssestCategory : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // GET: AssestCategory/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
