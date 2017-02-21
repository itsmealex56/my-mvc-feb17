using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WMSUCPECS.Areas.Security.Models;
using WMSUCPECS.Dal;

namespace WMSUCPECS.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        private IList<UserView> Users
        {
            get
            {
                if (Session["data"] == null)
                {
                    Session["data"] = new List<UserView>() {
                        new UserView {
                            Id = Guid.NewGuid(),
                            FirstName = "ALexander Kim",
                            LastName = "Waing",
                            Age = 20 ,
                            Gender =  "Male"
                        },
                    new UserView {
                        Id = Guid.NewGuid(),
                        FirstName = "Ysabel",
                        LastName = "Ortega",
                        Age = 18 ,
                        Gender = "Female"

                       }
                    };
                }
                return Session["data"] as List<UserView>;
                
            }
        }
        // GET: Security/Users
        public ActionResult Index()
        {
            using(var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             select new UserView
                         {
                             Id = user.Id,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Age = user.Age,
                             Gender = user.Gender
                         }).ToList();
                                             
                return View(users);
            }
            
        }

        // GET: Security/Users/Details/5
        public ActionResult Details(Guid id)
{
            return View(GetUser(id));
            
        }
         
        // GET: Security/Users/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new List<SelectListItem> {
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                },
                new SelectListItem
                {
                    Value = "Female",
                    Text = " Female" 
                }
            };
            return View();
        }

        // POST: Security/Users/Create
        [HttpPost]
        public ActionResult Create(UserView usermodel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View();
                using (var db = new DatabaseContext())
                {
                db.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = usermodel.FirstName,
                    LastName = usermodel.LastName,
                    Age = usermodel.Age,
                    Gender = usermodel.Gender

                });
                db.SaveChanges();
            }
                TempData["message"] = "Successfully created!";
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Edit/5
        public ActionResult Edit(Guid id)
        {
             return View(GetUser(id));
            
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UserView usermodel)
        {
          
            try
            {
                if (ModelState.IsValid == false)
                    return View();
                using (var db = new DatabaseContext())
                {
                  var user = db.Users.FirstOrDefault(u => u.Id == id);
                    
                    user.FirstName = usermodel.FirstName;
                    user.LastName = usermodel.LastName;
                    user.Age = usermodel.Age;
                    user.Gender = usermodel.Gender;

                    db.SaveChanges();
                }
                


                TempData["editmsg"] = "Successfully modified!";
             
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(Guid id)
        {
           return View(GetUser(id));
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                 using (var db = new DatabaseContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
		private UserView GetUser(Guid id)
        {
            using (var db = new DatabaseContext())
            {
                return (from user in db.Users
                        where user.Id == id
                        select new UserView
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Age = user.Age,
                            Gender = user.Gender
                        }).FirstOrDefault();

                
            }

        }
    }
}
