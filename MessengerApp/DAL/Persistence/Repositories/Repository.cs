using BLL.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
