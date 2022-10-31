using BlogProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Repository
{
    public interface IBlogRepository:IRepository<Blog>
    {
        Task<IEnumerable<Blog>> GetListWithCategory();
        Task<IEnumerable<Blog>> GetListWithCategoryByWriter(int id);
    }
}
