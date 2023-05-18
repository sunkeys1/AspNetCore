using AspCoreMVC.Data;
using AspCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreMVC.Controllers
{
    
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<User> objUserList = _db.Users.ToList();
            return View(objUserList);
        }
    }
}
