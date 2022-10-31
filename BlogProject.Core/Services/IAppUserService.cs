using BlogProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Services
{
   public interface IAppUserService:ICrudService<AppUser>
    {
        public AppUser GetByMail(string email);
    }
}
