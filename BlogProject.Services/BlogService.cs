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
   public class BlogService:IBlogService
    {
        private readonly IUnitOfWork _uow;

        public BlogService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Blog> Create(Blog item)
        {
            await _uow.Blogs.AddAsync(item);
            await _uow.SaveAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var value=await _uow.Blogs.GetByIdAsync(id);
            _uow.Blogs.Remove(value);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<Blog>> GetAll()
        {
            return await _uow.Blogs.GetAllAsync();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _uow.Blogs.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetListWithCategory()
        {
            return await _uow.Blogs.GetListWithCategory();
        }

        public async Task<IEnumerable<Blog>> GetListWithCategoryByWriter(int id)
        {
            return await _uow.Blogs.GetListWithCategoryByWriter(id);
        }

        public async Task Update(Blog item)
        {
            _uow.Blogs.Update(item);
            await _uow.SaveAsync();
        }
    }
}
