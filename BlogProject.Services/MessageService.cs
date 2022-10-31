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
   public class MessageService:IMessageService
    {
        private readonly IUnitOfWork _uow;

        public MessageService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Message> Create(Message item)
        {
            await _uow.Messages.AddAsync(item);
            await _uow.SaveAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var value = await _uow.Messages.GetByIdAsync(id);
            _uow.Messages.Remove(value);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<Message>> GetAll()
        {
            return await _uow.Messages.GetAllAsync();
        }

        public async Task<Message> GetById(int id)
        {
            return await _uow.Messages.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Message>> GetInboxWithMessageByWriter(int id)
        {
            return await _uow.Messages.GetInboxWithMessageByWriter(id);
        }

        public async Task<IEnumerable<Message>> GetSendBoxWithMessageByWriter(int id)
        {
            return await _uow.Messages.GetSendBoxWithMessageByWriter(id);
        }

        public async Task Update(Message item)
        {
            _uow.Messages.Update(item);
            await _uow.SaveAsync();
        }
    }
}
