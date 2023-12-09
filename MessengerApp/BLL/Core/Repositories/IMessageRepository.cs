using BLL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core.Repositories
{
    public interface IMessageRepository: IRepository<Message>
    {
        IEnumerable<Message> GetMessagesFromDialog(long DialogId);
    }
}
