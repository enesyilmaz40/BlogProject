using BlogProject.Core;
using BlogProject.Core.Repository;
using BlogProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data
{
   public class UnitOfWork:IUnitOfWork
    {
        private readonly Context _context;
        private AdminRepository _adminRepository;
        private AppRoleRepository _appRoleRepository;
        private AppUserRepository _appUserRepository;
        private BlogRepository _blogRepository;
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private MessageRepository _messageRepository;
        private NotificationRepository _notificationRepository;


        public UnitOfWork(Context context)
        {
            _context = context;
        }
        public IAdminRepository Admins => _adminRepository = _adminRepository ?? new AdminRepository(_context);

        public IAppRoleRepository AppRoles => _appRoleRepository = _appRoleRepository ?? new AppRoleRepository(_context);

        public IAppUserRepository AppUsers => _appUserRepository = _appUserRepository ?? new AppUserRepository(_context);

        public IBlogRepository Blogs => _blogRepository = _blogRepository ?? new BlogRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository = _commentRepository ?? new CommentRepository(_context);

        public IMessageRepository Messages => _messageRepository = _messageRepository ?? new MessageRepository(_context);

        public INotificationRepository Notifications => _notificationRepository = _notificationRepository ?? new NotificationRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
