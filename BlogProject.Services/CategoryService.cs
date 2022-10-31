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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Category> Create(Category item)
        {
            await _uow.Categories.AddAsync(item);
            await _uow.SaveAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var value = await _uow.Categories.GetByIdAsync(id);
            _uow.Categories.Remove(value);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _uow.Categories.GetAllAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _uow.Categories.GetByIdAsync(id);
        }

        public async Task Update(Category item)
        {
            _uow.Categories.Update(item);
            await _uow.SaveAsync();
        }
    }
}
