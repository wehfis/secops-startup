using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.Models
{
    public class User
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public string? Nickname { get; set; }
        public string? Password { get; set; }
        public ICollection<UserDialog> UserDialogs { get; set; }
    }
}
