using BlogProject.Core.Services;
using BlogProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IAppUserService _appUserService;
        private readonly ICategoryService _categoryService;

  

        public DashboardController(IBlogService blogService, IAppUserService appUserService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _appUserService = appUserService;
            _categoryService = categoryService;
        }

        
        public IActionResult Index()
        {

            var username = User.Identity.Name;
            var userName = _appUserService.GetByUserName(username).Id;

            ViewBag.blogCount= _blogService.GetAll().ToString().Count();
            ViewBag.writerBlogCount = _blogService.GetListWithCategoryByWriter(userName).ToString().Count();
            ViewBag.categoryCount = _categoryService.GetAll().ToString().Count();
            return View();

        }
    }
}
