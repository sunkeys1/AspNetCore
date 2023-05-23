using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorPages.Data;
using WebRazorPages.Models;

namespace WebRazorPages.Pages.Users
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _db;
        public User User { get; set; }
        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                User = _db.Users.Find(id);
            }
            
        }
        public IActionResult OnPost()
        {
            User? obj = _db.Users.Find(User.Id);
            if (obj == null)
            {
                NotFound();
            }
            _db.Users.Remove(obj);
            _db.SaveChanges();
            //TempData["success"] = "User deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
