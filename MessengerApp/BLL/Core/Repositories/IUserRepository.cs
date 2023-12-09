using BLL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        void CreateUser(User user);
        void AunthenticateUser(User user);
        void AddContact(long ContactId);
        void SendMessage(Message msg, User recipient);
    }
}
