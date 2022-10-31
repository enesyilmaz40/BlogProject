using BlogProject.Core.Models;
using BlogProject.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private Context _context => Context as Context;
        public CommentRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetListWithBlog()
        {
            return await _context.Comments.Include(x => x.Blog).ToListAsync();
        }
    }
}
