using System.Collections.Generic;

namespace BLL.Core.Domain
{
    public class Dialog
    {
        public long Id { get; set; }
        public ICollection<UserDialog> UserDialogs { get; set; }
        public ICollection<Message> Messages { get; } = new List<Message>();
    }
}
