using BlogProject.Core;
using BlogProject.Core.Models;
using BlogProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        ServiceResponse<IEnumerable<Admin>> response;


        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userList = await _adminService.GetAll();
            response = new ServiceResponse<IEnumerable<Admin>>
            {
                Data = userList,
                Success = true,
                Message = ""
            };
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _adminService.GetById(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Admin admin)
        {
            try
            {
                Admin values = new Admin();

                //values.AdminID = admin.AdminID;
                values.UserName = admin.UserName;
                values.Name = admin.Name;
                values.Role = admin.Role;
                values.ImageURL = admin.ImageURL;

                SHA256 shahash1 = SHA256.Create();
                byte[] deger = Encoding.UTF8.GetBytes(admin.Password);
                byte[] shaBytes = shahash1.ComputeHash(deger);
                values.Password = shaBytes.ToString();
                
                var value = await _adminService.Create(values);
                return Ok(value);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _adminService.Delete(id);
                var response = new ServiceResponse<int>
                {
                    Data = id,
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
        [HttpPut]
        public async Task<IActionResult> Update(Admin admin)
        {
            try
            {
                var values = await _adminService.GetById(admin.AdminID);

                values.Name = admin.Name;
                values.Role = admin.Role;
                values.UserName = admin.UserName;
                values.ImageURL = admin.ImageURL;

                SHA256 sha1Hash = SHA256.Create();
                byte[] degerBytes = Encoding.UTF8.GetBytes(admin.Password);
                byte[] shaBytes = sha1Hash.ComputeHash(degerBytes);
                values.Password = shaBytes.ToString();



                await _adminService.Update(values);
                var response = new ServiceResponse<int>
                {
                    Success = true,
                    Message = ""
                };
                return Ok(response);
            }
            catch (Exception e )
            {

                return BadRequest(new ServiceResponse<int>
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }


    }
}
