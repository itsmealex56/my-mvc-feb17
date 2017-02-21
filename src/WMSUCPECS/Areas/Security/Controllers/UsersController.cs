using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using WMSUCPECS.Areas.Security.Models;
using WMSUCPECS.Dal;

namespace WMSUCPECS.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        
        // GET: Security/Users
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             select new UserView
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Age = user.Age,
                                 Gender = user.Gender,
                                 EmploymentDate = user.EmploymentDate,
                                 Schools = user.Educations.Select(s => s.School).ToList()
                             }).ToList();

                return View(users);
            }

        }

        // GET: Security/Users/Details/5
        public ActionResult Details(int id)
        {
            return View(GetUser(id));

        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
           
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
                    var sql = @"exec uspCreateUser @guid,
                                    @fname,
                                    @lname,
                                    @age,
                                    @gender,
                                    @empDate,
                                    @school,
                                    @yrAttended";

                    var result = db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@guid", Guid.NewGuid()),
                        new SqlParameter("@fname", usermodel.FirstName),
                        new SqlParameter("@lname", usermodel.LastName),
                        new SqlParameter("@age", usermodel.Age),
                        new SqlParameter("@gender", usermodel.Gender),
                        new SqlParameter("@empDate", DateTime.UtcNow),
                        new SqlParameter("@school", "WMSU"),
                        new SqlParameter("@yrAttended", "2002"));

                    /*{
                        db.Users.Add(new User
                        {
                           // Id = Guid.NewGuid(),
                            FirstName = usermodel.FirstName,
                            LastName = usermodel.LastName,
                            Age = usermodel.Age,
                            Gender = usermodel.Gender,
                            EmploymentDate = usermodel.EmploymentDate 

                        });
                        db.SaveChanges();
                    }*/
                    if (result > 1)
                    
                        //TempData["message"] = "Successfully created!";

                        return RedirectToAction("Index");
                    
                    else
                        return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetUser(id));

        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserView usermodel)
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
                    user.EmploymentDate = usermodel.EmploymentDate; 
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
        public ActionResult Delete(int id)
        {
            return View(GetUser(id));
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
        private UserView GetUser(int id)
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
                            Gender = user.Gender,
                            EmploymentDate = user.EmploymentDate 
                        }).FirstOrDefault();


            }

        }
    }
}
