using BlogProject.Core.Models;
using BlogProject.Core.Services;
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
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryGetAll()
        {

            try
            {
                var values = await _categoryService.GetAll();
                var response = new ServiceResponse<IEnumerable<Category>>
                {
                    Data = values,
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
        public async Task<IActionResult> CategoryGetById(int id)
        {

            try
            {
                var value = await _categoryService.GetById(id);
                var response = new ServiceResponse<Category>
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
        [HttpPost]
        public async Task<IActionResult> CategoryAdd(Category p)
        {
            try
            {
                Category value = new Category();
                value.CategoryName = p.CategoryName;
                value.CategoryDescription = p.CategoryDescription;
                value.CategoryStatus = p.CategoryStatus;

                var categoryAdd = await _categoryService.Create(value);
                return Ok(new ServiceResponse<Category>
                {
                    Data = categoryAdd,
                    Message = "",
                    Success = true
                });


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
        [HttpDelete("{id}")]
        public async Task<IActionResult> CategoryDelete(int id)
        {

            try
            {
                await _categoryService.Delete(id);
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
        public async Task<IActionResult> CategoryUpdate(Category p)
        {
            try
            {
                var values = await _categoryService.GetById(p.CategoryID);
                values.CategoryName = p.CategoryName;
                values.CategoryDescription = p.CategoryDescription;
                values.CategoryStatus = p.CategoryStatus;

                await _categoryService.Update(values);
                return Ok(new ServiceResponse<Category> {
                
                    Data=values,
                    Success=true,
                    Message=""
                });
            }
            catch (Exception e)
            {

                return BadRequest(new ServiceResponse<int>
                {
                    Message = e.Message,
                    Success = false
                });
            }



         
        }
    }
}
