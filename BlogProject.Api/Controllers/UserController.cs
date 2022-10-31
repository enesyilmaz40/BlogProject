using BlogProject.Core.Dtos;
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
    public class UserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IAuthService _authService;
        ServiceResponse<IEnumerable<AppUser>> response;
        public UserController(IAppUserService appUserService, IAuthService authService)
        {
            _appUserService = appUserService;
            _authService = authService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var values = await _appUserService.GetAll();
                return Ok(values);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var values = await _appUserService.GetById(id);
                return Ok(values);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                
            }
          
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserForRegisterDto userForRegisterDto)
        {


            try
            {
                //var userExists = _authService.UserExist(userForRegisterDto.Email);
                //if (!userExists)
                //    return BadRequest();
                var registerResult = await _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                var result = _authService.CreateAccessToken(registerResult);
                if (result == null)
                {
                    //return Ok((AccessToken)null);
                    return BadRequest(new ServiceResponse<AccessToken>
                    {
                        Data = result,
                        Success = true,
                        Message = "Başarısız"
                    });
                }
                else
                {
                    return Ok(new ServiceResponse<AccessToken>
                    {
                        Data = result,
                        Success = true,
                        Message = "Başarılı"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new ServiceResponse<string>
                {
                    Data = null,
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

                await _appUserService.Delete(id);
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
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserForRegisterDto userForRegisterDto)
        {

            try
            {
                //var userExists = _authService.UserExist(userForRegisterDto.Email);
                //if (!userExists)
                //    return BadRequest();
                var registerResult = await _authService.Update(userForRegisterDto, userForRegisterDto.Password);
                var result = _authService.CreateAccessToken(registerResult);
                if (result == null)
                {
                    //return Ok((AccessToken)null);
                    return BadRequest(new ServiceResponse<AccessToken>
                    {
                        Data = result,
                        Success = true,
                        Message = "Başarısız"
                    });
                }
                else
                {
                    return Ok(new ServiceResponse<AccessToken>
                    {
                        Data = result,
                        Success = true,
                        Message = "Başarılı"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new ServiceResponse<string>
                {
                    Data = null,
                    Success = false,
                    Message = e.Message
                });
            }







        }

    }
}
