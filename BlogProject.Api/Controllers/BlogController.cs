using BlogProject.Core.Models;
using BlogProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IAppUserService _appUserService;
        ServiceResponse<IEnumerable<Blog>> response;

        public BlogController(IBlogService blogService, IAppUserService appUserService)
        {
            _blogService = blogService;
            _appUserService = appUserService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BlogGetAll()
        {

            try
            {
                var userList = await _blogService.GetAll();
                var response = new ServiceResponse<IEnumerable<Blog>>
                {
                    Data = userList,
                    Success = true,
                    Message = ""
                };
                return Ok(response);
            }
            catch (Exception e)
            {

                return BadRequest(new ServiceResponse<int>
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BlogGetById(int id)
        {

            try
            {
                var value = await _blogService.GetById(id);
                var response = new ServiceResponse<Blog>
                {
                    Data = value,
                    Success = true,
                    Message = ""

                };
                return Ok(response);
            }
            catch (Exception e)
            {

                return BadRequest(new ServiceResponse<int>
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }

       [HttpGet("GetListWithCategory")]
        public async Task<IActionResult> GetListWithCategory()
        {
            

            try
            {

                return Ok(await _blogService.GetListWithCategory());
            }
            catch (Exception e)
            {

                return BadRequest(new ServiceResponse<int>
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> BlogAdd(Blog blog)
        {
            Blog values = new Blog();

            try
            {
                values.BlogContent = blog.BlogContent;
                values.BlogTitle = blog.BlogTitle;
                values.BlogStatus = true;
                values.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                values.AppUserID = blog.AppUser.Id;
                values.CategoryID = blog.Category.CategoryID;


                var value = await _blogService.Create(values);
                return Ok(value);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> BlogDelete(int id)
        {
            try
            {
                await _blogService.Delete(id);
                var response = new ServiceResponse<int>
                {
                    Data = id,
                    Success = true,
                    Message = ""
                };
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(new ServiceResponse<int>
                {
                    Success = false,
                    Message = e.Message
                });
            }

        }
        [HttpPut]
        public async Task<IActionResult> BlogUpdate(Blog p)
        {

            try
            {
                var values = await _blogService.GetById(p.BlogID);
                values.BlogContent = p.BlogContent;
                values.BlogTitle = p.BlogTitle;
                values.BlogStatus = true;
                values.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                values.AppUserID = p.AppUser.Id;
                values.CategoryID = p.Category.CategoryID;

                await _blogService.Update(values);
                return Ok(values);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpGet("BlogListByWriter")]
        //[Authorize]
        public async Task<IActionResult> BlogListByWriter(int id)
        {
    

            ServiceResponse<IEnumerable<Blog>> response = new();
            try
            {
                AppUser user = new AppUser();
                user.Id = id;
                var values = await _blogService.GetListWithCategoryByWriter(user.Id);
                
                if(values!= null)
                {
                    response = new ServiceResponse<IEnumerable<Blog>>
                    {
                        Data = values,
                        Success = true,
                        Message = "Başarılı"
                    };
                }
                else
                {
                    response = new ServiceResponse<IEnumerable<Blog>>
                    {
                        Success = false,
                        Message = "Başarısız"
                    };
                }



            }
            catch (Exception e)
            {

                response = new ServiceResponse<IEnumerable<Blog>>
                {
                    Success = false,
                    Message = "Başarısız"
                };

            }
            return await Task.Run(() => new JsonResult(response));
        }
     
    }
}
