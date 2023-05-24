using DependencyInjectionTest.Models;
using DependencyInjectionTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DependencyInjectionTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScopedGuid _scoped1;
        private readonly IScopedGuid _scoped2;

        private readonly ISingeltonGuid _singelton1;
        private readonly ISingeltonGuid _singelton2;

        private readonly ITransientGuid _transient1;
        private readonly ITransientGuid _transient2;

        public HomeController(IScopedGuid scoped1,
            IScopedGuid scoped2,
            ITransientGuid transient1,
            ITransientGuid transient2,
            ISingeltonGuid singelton1,
            ISingeltonGuid singelton2)
        {
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singelton1 = singelton1;
            _singelton2 = singelton2;
            _transient1 = transient1;
            _transient2 = transient2;

        }

        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();
            messages.Append($"Transient 1 : {_transient1.GetGuid()}\n");
            messages.Append($"Transient 2 : {_transient2.GetGuid()}\n\n\n");

            messages.Append($"Scoped 1 : {_scoped1.GetGuid()}\n");
            messages.Append($"Scoped 2 : {_scoped2.GetGuid()}\n\n\n");

            messages.Append($"Singelton 1 : {_singelton1.GetGuid()}\n");
            messages.Append($"Singelton 2 : {_singelton2.GetGuid()}\n\n\n");
            return Ok(messages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}