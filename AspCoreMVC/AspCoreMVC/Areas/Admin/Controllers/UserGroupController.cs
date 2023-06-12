using AspCore.DataAccess.Repository.IRepository;
using AspCore.Models;
using AspCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspCoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserGroupController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserGroupController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<UserGroup> objUserGroupList = _unitOfWork.UserGroup.GetAll(includeProps:"User").ToList();
            
            return View(objUserGroupList);
        }
        //public IActionResult Add()
        //{

        //    //ViewBag.UserList = UserList;
        //    //ViewData["UserList"] = UserList;
        //    UserGroupVM userGroupVM = new()
        //    {
        //        UserList = _unitOfWork.User.GetAll().Select(u => new SelectListItem               // объединяем create(add) с update
        //        {
        //            Text = u.Login,
        //            Value = u.Id.ToString()
        //        }),
        //        UserGroup = new UserGroup()
        //    };
        //    return View(userGroupVM);
        //}
        public IActionResult Upadd(int? id)  // Upsert  (UpdateInsert) объединяем 2 в 1 
        {
            UserGroupVM userGroupVM = new()
            {
                UserList = _unitOfWork.User.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Login,
                    Value = u.Id.ToString()
                }),
                UserGroup = new UserGroup()
            };
            if (id == null || id == 0)
            {
                // add (create)
                return View(userGroupVM);
            }
            else
            {
                // update
                userGroupVM.UserGroup = _unitOfWork.UserGroup.Get(u => u.Id == id);
                return View(userGroupVM);
            }
        }
        [HttpPost]
        public IActionResult Upadd(UserGroupVM userGroupVM, IFormFile? file)   // было: public IActionResult Add(UserGroupVM userGroupVM)
        { 

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string userGroupPath = Path.Combine(wwwRootPath, @"images\usergroup");

                    if (!string.IsNullOrEmpty(userGroupVM.UserGroup.ImageUrl))
                    {
                        // delete old img
                        var oldImgPath = Path.Combine(wwwRootPath, userGroupVM.UserGroup.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(userGroupPath, fileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    userGroupVM.UserGroup.ImageUrl = @"\images\usergroup\" + fileName; 
                }
                if(userGroupVM.UserGroup.Id == 0 || userGroupVM.UserGroup.Id == null)
                {
                    userGroupVM.UserGroup.CreatedDate = DateTime.Now;
                    userGroupVM.UserGroup.Code = "Active";
                    _unitOfWork.UserGroup.Add(userGroupVM.UserGroup);
                    TempData["success"] = "User Group added successfully";
                }
                else
                {
                    _unitOfWork.UserGroup.Update(userGroupVM.UserGroup);
                    TempData["success"] = "User Group updated successfully";
                }
                
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            else
            {
                userGroupVM.UserList = _unitOfWork.User.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Login,
                    Value = u.Id.ToString()
                });       
                return View(userGroupVM);
            } 
        }
        ///
        //public IActionResult Edit(int? id)                    // убираем Edit тк мы объединили его с Create(Add) (Upadd)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    UserGroup? userGroupFromDb = _unitOfWork.UserGroup.Get(u => u.Id == id);
        //    //User? userFromDb1 = _db.Users.FirstOrDefault(a => a.Id == id);            
        //    //User? userFromDb2 = _db.Users.Where(a => a.Id == id).FirstOrDefault();    //аналогичны верхнему
        //    if (userGroupFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(userGroupFromDb);
        //}
        //[HttpPost]
        //public IActionResult Edit(UserGroup obj)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        //obj.Created = _db.  как вернуть время из бд чтобы не сбрасывалось в 0000 ?? !! => solution: добавить <input asp-for="что хотим передать" hidden/> в Edit в нашем случае (хз норм ли это)
        //        _unitOfWork.UserGroup.Update(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "User Group updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    UserGroup? userGroupFromDb = _unitOfWork.UserGroup.Get(u => u.Id == id);

        //    if (userGroupFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(userGroupFromDb);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    UserGroup? obj = _unitOfWork.UserGroup.Get(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        NotFound();
        //    }

        //    _unitOfWork.UserGroup.Delete(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "User Group deleted successfully";
        //    return RedirectToAction("Index");

        //}
        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserGroup> objUserGroupList = _unitOfWork.UserGroup.GetAll(includeProps: "User").ToList();
            return Json(new { data = objUserGroupList } );
        }
        public IActionResult Delete(int? id)
        {
            var userGroupDeleting = _unitOfWork.UserGroup.Get(u => u.Id == id);
            if(userGroupDeleting == null)
            {
                return Json(new { success = false, message = "Error while deleting!" });
            }
            var oldImgPath = 
                Path.Combine(_webHostEnvironment.WebRootPath, 
                userGroupDeleting.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImgPath))
            {
                System.IO.File.Delete(oldImgPath);
            }
            _unitOfWork.UserGroup.Delete(userGroupDeleting);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully" });
        }
        #endregion
    }
}
