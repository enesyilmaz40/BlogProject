using BlogProject.Core;
using BlogProject.Core.Models;
using BlogProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Services
{
   public class AppRoleService:IAppRoleService
    {
        private readonly IUnitOfWork _uow;

        public AppRoleService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<AppRole> Create(AppRole item)
        {
            await _uow.AppRoles.AddAsync(item);
            await _uow.SaveAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var value = await _uow.AppRoles.GetByIdAsync(id);
            _uow.AppRoles.Remove(value);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<AppRole>> GetAll()
        {
            return await _uow.AppRoles.GetAllAsync();
        }

        public async Task<AppRole> GetById(int id)
        {
            return await _uow.AppRoles.GetByIdAsync(id);
        }

        public async Task Update(AppRole item)
        {
            _uow.AppRoles.Update(item);
            await _uow.SaveAsync();
        }
    }
}
