using System.Collections.Generic;

namespace BLL.Core.Domain
{
    public class Dialog
    {
        public long Id { get; set; }
        public long? SenderId { get; set; }
        public long? RecipientId { get; set; }
        public User? Sender { get; set; }
        public User? Recipient { get; set; }
        public ICollection<Message> Messages { get; } = new List<Message>();
    }
}
