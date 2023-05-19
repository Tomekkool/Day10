using Microsoft.AspNetCore.Mvc;

using P01PlayersMVCWebApp.Models;

namespace P01PlayersMVCWebApp.Controllers
{
    public class TestingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SampleText()
        {

            ViewBag.MyOwnMessage = "hello from controller";
            return View();
        }

        public IActionResult PersonsList()
        {
            var persons = new List<Person>()
            {
            new Person() {Id=1, Name="a",Age=1},
            new Person() {Id=2, Name="b",Age=1},
            new Person() {Id=3, Name="c",Age=1},

            };
            
            return View(persons);
        }
        public IActionResult NewPersonsList()
        {
            var persons = new List<Person>()
            {
            new Person() {Id=1, Name="a",Age=1},
            new Person() {Id=2, Name="b",Age=1},
            new Person() {Id=3, Name="c",Age=1},

            };

            return View(persons);
        }

    }
}
