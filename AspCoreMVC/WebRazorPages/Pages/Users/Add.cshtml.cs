using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorPages.Data;
using WebRazorPages.Models;

namespace WebRazorPages.Pages.Users
{
    [BindProperties]
    public class AddModel : PageModel
    {
        private readonly AppDbContext _db;
        public User User { get; set; }
        public AddModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            User.Created = DateTime.Now;
            User.UserState = "Active";
            User.GroupId = 2;
            _db.Users.Add(User);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
