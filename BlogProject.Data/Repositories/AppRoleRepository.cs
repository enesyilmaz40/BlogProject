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
    public class AppRoleRepository : Repository<AppRole>, IAppRoleRepository
    {
        public AppRoleRepository(Context context) : base(context)
        {
        }
    }
}
