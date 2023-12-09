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
    public class DialogRepository : Repository<Dialog>, IDialogRepository
    {
        public DialogRepository(DbAplicationContext context) : base(context)
        {
        }
    }
}
