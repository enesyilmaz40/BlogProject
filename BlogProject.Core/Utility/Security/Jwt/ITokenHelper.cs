using BlogProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Utility.Security.Jwt
{
    public interface ITokenHelper
    {
      AccessToken CreateToken(AppUser user, IEnumerable<OperationClaim> operationClaims);
    }
}
