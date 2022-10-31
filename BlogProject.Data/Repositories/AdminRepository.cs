using BlogProject.Core.Models;
using BlogProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.Repositories
{
   public class AdminRepository:Repository<Admin>,IAdminRepository
    {
        //private Context Context => Context as Context;

        public AdminRepository(Context context):base(context)
        {

        }



    }
}
