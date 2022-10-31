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
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _uow;

        public AdminService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Admin> Create(Admin item)
        {
            await _uow.Admins.AddAsync(item);
            await _uow.SaveAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var value = await _uow.Admins.GetByIdAsync(id);
            _uow.Admins.Remove(value);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _uow.Admins.GetAllAsync();
        }

        public async Task<Admin> GetById(int id)
        {
            return await _uow.Admins.GetByIdAsync(id);
        }

        public async Task Update(Admin item)
        {
            _uow.Admins.Update(item);
            await _uow.SaveAsync();

        }
    }
}
