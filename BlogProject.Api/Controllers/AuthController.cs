using BlogProject.Core.Dtos;
using BlogProject.Core.Models;
using BlogProject.Core.Services;
using BlogProject.Core.Utility.Security.Jwt;
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
    public class AuthController : ControllerBase
    {
        //Bakılacak
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {

            //if(userToLogin == null)
            //{
            //    return BadRequest();
            //}
            //var result =  _authService.CreateAccessToken(userToLogin);
            //if(result!= null)
            //{
            //    return Ok();
            //}
            //return BadRequest((AccessToken)null);
            //try
            //{
            var userToLogin = await _authService.Login(userForLoginDto);
            var result = _authService.CreateAccessToken(userToLogin);
            if (userToLogin != null)
            {
                return Ok(new ServiceResponse<AccessToken>
                {
                    Data = result,
                    Success = true,
                    Message = "Success"
                });
            }
            else
            {
                return BadRequest(new ServiceResponse<string>
                {
                    Data = null,
                    Success = false,
                    Message = "LoginError"
                });
            }
            //}
            //catch (Exception e)
            //{

            //    return BadRequest(new ServiceResponse<string>
            //    {
            //        Data = null,
            //        Success = false,
            //        Message = e.Message
            //    });
            //}
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
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
    }
}
