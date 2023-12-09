using System;
using BLL.Core.Repositories;
using BLL.Core.Domain;
using DAL.DBContex;

namespace DAL.Persistence.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbAplicationContext context) : base(context)
        {
        }

        public User AddContact(long ContactId)
        {
            throw new NotImplementedException();
        }

        public void AunthenticateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Dialog SendMessage(Message msg, User recipient)
        {
            throw new NotImplementedException();
        }
    }
}
