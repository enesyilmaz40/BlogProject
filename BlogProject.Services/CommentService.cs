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
   public class CommentService:ICommentService
    {
        private readonly IUnitOfWork _uow;

        public CommentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Comment> Create(Comment item)
        {
            await _uow.Comments.AddAsync(item);
            await _uow.SaveAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var value = await _uow.Comments.GetByIdAsync(id);
            _uow.Comments.Remove(value);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _uow.Comments.GetAllAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _uow.Comments.GetByIdAsync(id);
        }

        public async Task Update(Comment item)
        {
            _uow.Comments.Update(item);
            await _uow.SaveAsync();
        }
    }
}
