using AspCore.DataAccess.Repository.IRepository;
using AspCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspCoreMVC.Areas.User.Controllers
{
    [Area("Usser")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<UserGroup> userGroupList = _unitOfWork.UserGroup.GetAll(includeProps:"User");
            return View(userGroupList);
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