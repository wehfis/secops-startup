using System;
using BLL.Core.Repositories;
using BLL.Core.Domain;

namespace DAL.Persistence.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
    }
}
