﻿using AspCore.DataAccess.Data;
using AspCore.DataAccess.Repository.IRepository;
using AspCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCore.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository db)
        {
            _userRepository = db;
        }
        public IActionResult Index()
        {
            List<User> objUserList = _userRepository.GetAll().ToList();
            return View(objUserList);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(User obj)
        {
            if(obj.Login != null && obj.Login.ToLower() == obj.Password.ToLower())
            {
                ModelState.AddModelError("password", "Password cannot match login");
            }
            
            if (ModelState.IsValid)
            {
                obj.Created = DateTime.Now;
                obj.UserState = "Active";
                obj.GroupId = 2;
                _userRepository.Add(obj);
                _userRepository.Save();
                TempData["success"] = "User added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            User? userFromDb = _userRepository.Get(u => u.Id == id);
            //User? userFromDb1 = _db.Users.FirstOrDefault(a => a.Id == id);            
            //User? userFromDb2 = _db.Users.Where(a => a.Id == id).FirstOrDefault();    //аналогичны верхнему
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }
        [HttpPost]
        public IActionResult Edit(User obj)
        {
            
            if (ModelState.IsValid)
            {
                //obj.Created = _db.  как вернуть время из бд чтобы не сбрасывалось в 0000 ?? !! => solution: добавить <input asp-for="что хотим передать" hidden/> в Edit в нашем случае (хз норм ли это)
                _userRepository.Update(obj);
                _userRepository.Save();
                TempData["success"] = "User updated successfully";
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
            User? userFromDb = _userRepository.Get(u=>u.Id==id);
           
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            User? obj = _userRepository.Get(u => u.Id == id);
            if(obj == null)
            {
                NotFound();
            }
            _userRepository.Delete(obj);
            _userRepository.Save();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction("Index");
            
        }
    }
}
