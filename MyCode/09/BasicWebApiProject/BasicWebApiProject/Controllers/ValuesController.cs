using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasicWebApiProject.Controllers
{
    public class FruitController : Controller
    {
        private readonly List<string> _fruit = new List<string>
            {
                "Pear",
                "Lemon",
                "Peach"
            };

        public IEnumerable<string> Index()
        {
            return _fruit;
        }

        public IActionResult View(int id)
        {
            if (id >= 0 && id < _fruit.Count)
            {
                return Ok(_fruit[id]);
            }

            return NotFound();
        }
    }
}