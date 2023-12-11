using BLL.Core.Domain;
using BLL.Core.Repositories;
using DAL.DBContex;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence.Repositories
{
    public class DialogRepository : Repository<Dialog>, IDialogRepository
    {
        private readonly DbAplicationContext _context;

        public DialogRepository(DbAplicationContext context) : base(context)
        {
            _context = context;
        }

        public Dialog FindDialogByUsers(long userId1, long userId2)
        {
            var dialog = _context.Set<Dialog>()
                .Include(d => d.UserDialogs)
                .ThenInclude(ud => ud.User)
                .SingleOrDefault(d =>
                    d.UserDialogs.Any(ud => ud.UserId == userId1) &&
                    d.UserDialogs.Any(ud => ud.UserId == userId2));

            return dialog;
        }
    }
}
