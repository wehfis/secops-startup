﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ClientSocketLogic.EventModel
{
    public enum EventType
    {
        Login,
        LoginErrorResponse,
        LoginSuccessResponse,
        GetAllUsersExceptCurrent,
        Error,
        Register,
        RegisterErrorResponse,
        RegisterSuccessResponse,
        GetAllMessagesFromDialog,
        GetAllMessagesFromDialogResponse,
        SendMessage
    }
}
