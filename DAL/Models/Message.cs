using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecFlowMessenger.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string? Content { get; set; }
        public long? DialogId { get; set; }
        public DateTime? Time { get; set; }
        public long? SenderId { get; set; }
        public long? ResipientId { get; set; }
        public Dialog? Dialog { get; set; }
    }
}
