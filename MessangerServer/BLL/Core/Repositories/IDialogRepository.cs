using BLL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core.Repositories
{
    public interface IDialogRepository: IRepository<Dialog>
    {
        Dialog FindDialogByUsers(long userId1, long userId2);
    }
}
