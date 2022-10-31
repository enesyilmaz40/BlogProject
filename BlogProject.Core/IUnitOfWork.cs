using BlogProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core
{
    public interface IUnitOfWork:IDisposable
    {
        IAdminRepository Admins { get; }
        IAppRoleRepository AppRoles { get; }
        IAppUserRepository AppUsers { get; }
        IBlogRepository Blogs { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IMessageRepository Messages { get; }
        INotificationRepository Notifications { get; }
        Task<int> SaveAsync();


    }
}
