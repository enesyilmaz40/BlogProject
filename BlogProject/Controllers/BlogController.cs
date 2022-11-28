
using BlogProject.Core;
using BlogProject.Core.Services;
using BlogProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogService _blogService;
        private readonly IAppUserService _appUserService;
        public BlogController(IBlogService blogService, IAppUserService appUserService)
        {
            _blogService = blogService;
            _appUserService = appUserService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _blogService.GetListWithCategory();
            return View(values);
        }
        //public async Task<IActionResult> BlogReadAll(int id)
        //{
        //    ViewBag.i = id;
        //    var values = _blogService.GetById(id);
        //    return View(values);
        //}
    }
}
