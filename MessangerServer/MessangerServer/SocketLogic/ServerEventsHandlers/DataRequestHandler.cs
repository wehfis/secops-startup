using BLL.Core.Domain;
using BLL.Core.Repositories;
using DAL.DBContex;
using DAL.Persistence.Repositories;
using MessangerServer.SocketLogic.DTOs;
using MessangerServer.SocketLogic.SocketEventsGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

            string currentUserEmail = eventParam.Parameters["currentUserEmail"].ToString();
            string dialogUserEmail = eventParam.Parameters["dialogUserEmail"].ToString();

            var currentUser = userRepository.FirstOrDefault(user => user.Email == currentUserEmail);
            var anotherUser = userRepository.FirstOrDefault(user => user.Email == dialogUserEmail);
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
                    var messagesFromDialogUpdated = dialogRepository.GetDialogWithMessages(dialog.Id);
                    var dtoResult = messagesFromDialogUpdated.Messages.Select(m => new MessageDTO { SenderEmail = m.Sender.Email, Content = m.Content, Time = m.Time }).OrderBy(m => m.Time).ToList();

                    var successResponseEvent = ResponseGenerator.GetAllMessagesFromDialogResponse(dtoResult);
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

        public static void HandleSendMessageToDialog(Event eventParam)
        {
            DbAplicationContext Context = new DbAplicationContext();
            IUserRepository userRepository = new UserRepository(Context);
            IDialogRepository dialogRepository = new DialogRepository(Context);
            IMessageRepository messageRepository = new MessageRepository(Context);

            string senderUserEmail = eventParam.Parameters["senderUserEmail"].ToString();
            string receiverUserEmail = eventParam.Parameters["receiverUserEmail"].ToString();
            string messageToSend = eventParam.Parameters["message"].ToString();

            var senderUser = userRepository.FirstOrDefault(user => user.Email == senderUserEmail);
            var receiverUser = userRepository.FirstOrDefault(user => user.Email == receiverUserEmail);
            if (senderUser == null || receiverUser == null)
            {
                var message = "Incorrect receiver or sender!";
                var response = ResponseGenerator.GenerateErrorResponse(EventType.Error, message);
                SocketInitializer.serverSocketManager.SendEvent(response);
            }
            else
            {
                var dialog = dialogRepository.FindDialogByUsers(senderUser.Id, receiverUser.Id);

                if (dialog != null)
                {
                    var message = new Message
                    {
                        Content = messageToSend,
                        Time = DateTime.Now,
                        SenderId = senderUser.Id,
                        DialogId = dialog.Id
                    };
                    messageRepository.Add(message);
                    Context.SaveChanges();
                    var messagesFromDialogUpdated = dialogRepository.GetDialogWithMessages(dialog.Id);
                    var dtoResult = messagesFromDialogUpdated.Messages.Select(m => new MessageDTO { SenderEmail = m.Sender.Email, Content = m.Content, Time = m.Time }).OrderBy(m => m.Time).ToList();

                    var successResponseEvent = ResponseGenerator.GetAllMessagesFromDialogResponse(dtoResult);
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
