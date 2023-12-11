using System;

namespace BLL.Core.Domain
{
    public class Message
    {
        public long Id { get; set; }
        public string? Content { get; set; }
        public long? DialogId { get; set; }
        public DateTime? Time { get; set; }
        public long? SenderId { get; set; }
        public User? Sender { get; set; }
        public Dialog? Dialog { get; set; }
    }
}
