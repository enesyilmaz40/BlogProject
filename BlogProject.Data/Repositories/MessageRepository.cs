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
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private Context _context => Context as Context;
        public MessageRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Message>> GetInboxWithMessageByWriter(int id)
        {
            return await _context.Messages.Include(x => x.ReceiverUser).Where(y => y.SenderID == id).ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetSendBoxWithMessageByWriter(int id)
        {
            return await _context.Messages.Include(x => x.SenderUser).Where(y => y.ReceiverID == id).ToListAsync();
        }
    }
}
