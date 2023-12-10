using BLL.Core.Domain;
using BLL.Core.Repositories;
using DAL.DBContex;
using DAL.Persistence.Repositories;
using MessangerServer.SocketLogic.SocketEventsGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServer.SocketLogic.ServerEventsHandlers
{
    public static class DataRequestHandler
    {

        public static void HandleGetAllUsersExceptCurrent(Event eventParam)
        {
            DbAplicationContext Context = new DbAplicationContext();
            IUserRepository userRepository = new UserRepository(Context);

            string email = eventParam.Parameters["email"].ToString();
            string password = eventParam.Parameters["password"].ToString();

            var tryGetUser = userRepository.Find(user => user.Email != email );
            if (tryGetUser == null)
            {
                var message = "No users found";
                var response = ResponseGenerator.GenerateErrorResponse(EventType.Error, message);
                SocketInitializer.serverSocketManager.SendEvent(response);
            }
            else
            {
                var sucessResponseEvent = ResponseGenerator.GetAllUsersExceptCurrentResponse(EventType.GetAllUsersExceptCurrent, tryGetUser);
                SocketInitializer.serverSocketManager.SendEvent(sucessResponseEvent);
            }
        }
    }
}
