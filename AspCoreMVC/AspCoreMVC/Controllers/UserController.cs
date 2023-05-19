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
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(User obj)
        {
            if (ModelState.IsValid)
            {
                obj.Created = DateTime.Now;
                obj.UserState = "Active";
                obj.GroupId = 2;
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
