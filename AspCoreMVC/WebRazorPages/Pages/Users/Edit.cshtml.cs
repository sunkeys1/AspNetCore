using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorPages.Data;
using WebRazorPages.Models;

namespace WebRazorPages.Pages.Users
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        public User User { get; set; }
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                User = _db.Users.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {  
                _db.Users.Update(User);
                _db.SaveChanges();
                TempData["success"] = "User updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
