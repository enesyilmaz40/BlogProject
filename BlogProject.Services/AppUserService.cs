using BlogProject.Core;
using BlogProject.Core.Models;
using BlogProject.Core.Services;
using BlogProject.Core.Utility.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Services
{
   public class AppUserService:IAppUserService
    {
        private readonly IUnitOfWork _uow;
     
        public AppUserService(IUnitOfWork uow)
        {
            _uow = uow;
        
        }

        public async Task<AppUser> Create(AppUser item)
        {
            await _uow.AppUsers.AddAsync(item);
            await _uow.SaveAsync();
            return item;
        }

  

        public async Task Delete(int id)
        {
            var value = await _uow.AppUsers.GetByIdAsync(id);
            _uow.AppUsers.Remove(value);
            await _uow.SaveAsync();


        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _uow.AppUsers.GetAllAsync();
        }

        public async Task<AppUser> GetById(int id)
        {
            return await _uow.AppUsers.GetByIdAsync(id);
        }

        public  AppUser GetByMail(string email)
        {
            var userwithmail = _uow.AppUsers.FindQuery(u => u.Email == email);
            return userwithmail.FirstOrDefault();
        }

        public AppUser GetByUserName(string userName)
        {
            var userwithusername =  _uow.AppUsers.FindQuery(u => u.UserName == userName);
            return userwithusername.FirstOrDefault();
        }

        public IEnumerable<OperationClaim> GetClaims(AppUser user)
        {
            return  _uow.AppUsers.GetClaims(user);
        }

        public async Task Update(AppUser item)
        {
            _uow.AppUsers.Update(item);
            await _uow.SaveAsync();
        }

      
    }
}
