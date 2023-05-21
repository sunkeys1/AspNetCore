using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorPages.Data;
using WebRazorPages.Models;

namespace WebRazorPages.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public List<User> UserList { get; set; }  
        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            UserList = _db.Users.ToList();
            
        }
    }
}
