using _1911060839_Vuthidiemlinh_BigSchool.Models;
using _1911060839_Vuthidiemlinh_BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1911060839_Vuthidiemlinh_BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        // GET: Courses
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModels)
        {
            if (!ModelState.IsValid)
            {
                viewModels.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModels);
            }
            var courses = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModels.GetDateTime(),
                CategoryId = viewModels.Category,
                Place = viewModels.Place,

            };
            _dbContext.Courses.Add(courses);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");


        }
        

        
    }
}