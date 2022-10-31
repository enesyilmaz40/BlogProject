using BlogProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Services
{
    public interface IMessageService : ICrudService<Message>
    {
        Task<IEnumerable<Message>> GetInboxWithMessageByWriter(int id);
        Task<IEnumerable<Message>> GetSendBoxWithMessageByWriter(int id);
    }
}
