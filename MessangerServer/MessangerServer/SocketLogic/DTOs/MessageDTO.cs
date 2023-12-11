using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServer.SocketLogic.DTOs
{
    public class MessageDTO
    {
        public string? SenderEmail { get; set; }
        public string? Content { get; set; }
        public DateTime? Time { get; set; }
    }
}
