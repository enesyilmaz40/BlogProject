using BlogProject.Core;
using BlogProject.Core.Dtos;
using BlogProject.Core.Models;
using BlogProject.Core.Services;
using BlogProject.Core.Utility.Security.Hashing;
using BlogProject.Core.Utility.Security.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenHelper _tokenHelper;
        

        public AuthService(IUnitOfWork uow, ITokenHelper tokenHelper)
        {
            _uow = uow;
            _tokenHelper = tokenHelper;

        }

   

        public AccessToken CreateAccessToken(AppUser user)
        {
            var claims =  _uow.AppUsers.GetClaims(user);
            var accessToken =  _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }

        public async Task<AppUser> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _uow.AppUsers.SingleOrDefaultAsync(x => x.Email == userForLoginDto.Email);
            if (user == null) return null;
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,user.passwordHash2,user.PasswordSalt)) return null;

            return user;
           
        }

        public async Task<AppUser> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new AppUser
            {
                Email = userForRegisterDto.Email,
                NameSurname = userForRegisterDto.FirstName + " " + userForRegisterDto.LastName,
                passwordHash2 = passwordHash,
                PasswordSalt = passwordSalt,

            };
            await _uow.AppUsers.AddAsync(user);
            await _uow.SaveAsync();
            return user;
        }

        public async Task<AppUser> Update(UserForRegisterDto user, string password)
        {
            var userid = await _uow.AppUsers.GetByIdAsync(user.Id);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            userid.Email = user.Email;
            userid.NameSurname = user.FirstName+" "+user.LastName;
            userid.passwordHash2 = passwordHash;
            userid.PasswordSalt = passwordSalt;

             _uow.AppUsers.Update(userid);
            await _uow.SaveAsync();
            return userid;


        }

        public bool UserExist(string email)
        {
            var userValue = _uow.AppUsers.Find(x => x.Email == email).SingleOrDefault();
            if (userValue != null)
            {
                return true;
            }
            return false;
        }

      
    }
}
