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
   public class NotificationService:INotificationService
    {
        private readonly IUnitOfWork _uow;

        public NotificationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<Notification> Create(Notification item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notification>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Notification item)
        {
            throw new NotImplementedException();
        }
    }
}
