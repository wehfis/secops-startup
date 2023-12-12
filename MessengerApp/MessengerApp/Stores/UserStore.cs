using MessengerApp.ClientSocketLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.Stores
{
    public static class UserStore
    {
        public static User? currentUser { get; set; }
    }
}
