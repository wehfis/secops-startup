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

            var tryGetUser = userRepository.Find(user => user.Email != email );
            if (tryGetUser == null)
            {
                var message = "No users found";
                var response = ResponseGenerator.GenerateErrorResponse(EventType.Error, message);
                SocketInitializer.serverSocketManager.SendEvent(response);
            }
            else
            {
                var sucessResponseEvent = ResponseGenerator.GetAllUsersExceptCurrentResponse(tryGetUser);
                SocketInitializer.serverSocketManager.SendEvent(sucessResponseEvent);
            }
        }
        public static void HandleGetAllMessagesFromDialog(Event eventParam)
        {
            DbAplicationContext Context = new DbAplicationContext();
            IUserRepository userRepository = new UserRepository(Context);
            IDialogRepository dialogRepository= new DialogRepository(Context);

            string currentUserEmail = eventParam.Parameters["current_user"].ToString();
            string anotherUserEmail = eventParam.Parameters["another_user"].ToString();

            var currentUser = userRepository.FirstOrDefault(user => user.Email == currentUserEmail);
            var anotherUser = userRepository.FirstOrDefault(user => user.Email == anotherUserEmail);
            if (anotherUser == null || currentUser == null)
            {
                var message = "Incorrect receiver or sender!";
                var response = ResponseGenerator.GenerateErrorResponse(EventType.Error, message);
                SocketInitializer.serverSocketManager.SendEvent(response);
            }
            else
            {
                var dialog = dialogRepository.FindDialogByUsers(currentUser.Id, anotherUser.Id);

                if (dialog != null)
                {
                    var messagesFromDialog = dialog.Messages;

                    var successResponseEvent = ResponseGenerator.GetAllMessagesFromDialogResponse(messagesFromDialog);
                    SocketInitializer.serverSocketManager.SendEvent(successResponseEvent);
                }
                else
                {
                    var message = "No dialog found between users!";
                    var response = ResponseGenerator.GenerateErrorResponse(EventType.Error, message);
                    SocketInitializer.serverSocketManager.SendEvent(response);
                }
            }
        }
    }
}
