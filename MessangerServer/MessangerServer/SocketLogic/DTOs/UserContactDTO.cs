﻿using BLL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServer.SocketLogic.DTOs
{
    public class UserContactDTO
    {
        public string? Email { get; set; }
        public string? Nickname { get; set; }
    }
}
