using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServer.SocketLogic.SocketManager.EventModel
{
    [Serializable]
    public class Event
    {
        public EventType EventType { get; set; }
        public Dictionary<string, object>? Parameters { get; set; }
    }
}
