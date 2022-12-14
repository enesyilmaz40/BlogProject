using BlogProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Repository
{
    public interface ICommentRepository:IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetListWithBlog();
    }
}
