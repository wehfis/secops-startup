using BLL.Core.Domain;
using BLL.Core.Repositories;
using DAL.DBContex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DbAplicationContext context) : base(context)
        {
        }
    }
}
