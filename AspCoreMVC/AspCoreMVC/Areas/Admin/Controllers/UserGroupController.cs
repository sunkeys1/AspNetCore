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
        public UserGroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<UserGroup> objUserGroupList = _unitOfWork.UserGroup.GetAll().ToList();
            
            return View(objUserGroupList);
        }
        public IActionResult Add()
        {
            
            //ViewBag.UserList = UserList;
            //ViewData["UserList"] = UserList;
            UserGroupVM userGroupVM = new()
            {
                UserList = _unitOfWork.User.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Login,
                    Value = u.Id.ToString()
                }),
                UserGroup = new UserGroup()
            };
            return View(userGroupVM);
        }
        [HttpPost]
        public IActionResult Add(UserGroupVM userGroupVM)
        { 

            if (ModelState.IsValid)
            {
                userGroupVM.UserGroup.CreatedDate = DateTime.Now;
                userGroupVM.UserGroup.Code = "Active";
                _unitOfWork.UserGroup.Add(userGroupVM.UserGroup);
                _unitOfWork.Save();
                TempData["success"] = "User Group added successfully";
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
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            UserGroup? userGroupFromDb = _unitOfWork.UserGroup.Get(u => u.Id == id);
            //User? userFromDb1 = _db.Users.FirstOrDefault(a => a.Id == id);            
            //User? userFromDb2 = _db.Users.Where(a => a.Id == id).FirstOrDefault();    //аналогичны верхнему
            if (userGroupFromDb == null)
            {
                return NotFound();
            }
            return View(userGroupFromDb);
        }
        [HttpPost]
        public IActionResult Edit(UserGroup obj)
        {

            if (ModelState.IsValid)
            {
                //obj.Created = _db.  как вернуть время из бд чтобы не сбрасывалось в 0000 ?? !! => solution: добавить <input asp-for="что хотим передать" hidden/> в Edit в нашем случае (хз норм ли это)
                _unitOfWork.UserGroup.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "User Group updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            UserGroup? userGroupFromDb = _unitOfWork.UserGroup.Get(u => u.Id == id);

            if (userGroupFromDb == null)
            {
                return NotFound();
            }
            return View(userGroupFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            UserGroup? obj = _unitOfWork.UserGroup.Get(u => u.Id == id);
            if (obj == null)
            {
                NotFound();
            }
            _unitOfWork.UserGroup.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "User Group deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
