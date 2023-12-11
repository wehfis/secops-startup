using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.Models
{
    public class Dialog
    {
        public long Id { get; set; }
        public ICollection<UserDialog> UserDialogs { get; set; }
        public ICollection<Message> Messages { get; } = new List<Message>();
    }
}
