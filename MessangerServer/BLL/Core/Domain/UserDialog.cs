using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core.Domain
{
    public class UserDialog
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long DialogId { get; set; }
        public Dialog Dialog { get; set; }
    }
}
