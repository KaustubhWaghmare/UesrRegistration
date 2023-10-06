using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Data;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;

        public UserController( ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Users.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User model)
        {
            if(ModelState.IsValid)
            {
                var usr = new User()
                {
                    Name = model.Name,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    Address = model.Address,
                    ContactNumber = model.ContactNumber
                };
                context.Users.Add(usr);
                context.SaveChanges();
                TempData["error"] = "Record Saved Successfully!";
                return RedirectToAction("index");
            }
            else
            {
                TempData["message"] = "Empty Field can't Submit";
                return View(model);
            }
            
        }
        public IActionResult Delete(int id)
        {   var usr=context.Users.SingleOrDefault(x => x.Id == id);
            context.Users.Remove(usr);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";
            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int id)
        {
            var usr = context.Users.SingleOrDefault(x => x.Id == id);
            var result = new User()
            {
                Name = usr.Name,
                Email = usr.Email,
                DateOfBirth = usr.DateOfBirth,
                Gender = usr.Gender,
                Address = usr.Address,
                ContactNumber = usr.ContactNumber
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(User model)
        {
            var usr = new User()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Address = model.Address,
                ContactNumber = model.ContactNumber
            };
            context.Users.Update(usr);
            context.SaveChanges();
            TempData["error"] = "Record Updated Successfully!";
            return RedirectToAction("Index");
        }
    }
}
