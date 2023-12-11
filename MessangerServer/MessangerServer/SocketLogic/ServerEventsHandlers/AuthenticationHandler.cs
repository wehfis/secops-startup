using Azure;
using BLL.Core.Domain;
using BLL.Core.Repositories;
using DAL.DBContex;
using DAL.Persistence.Repositories;
using MessangerServer.SocketLogic.SocketEventsGenerators;

namespace MessangerServer.SocketLogic
{
    public static class AuthenticationHandler
    {

        public static void HandleLogin(Event eventParam)
        {
            DbAplicationContext loginContext = new DbAplicationContext();
            IUserRepository userRepository = new UserRepository(loginContext);

            string email = eventParam.Parameters["email"].ToString();
            string password = eventParam.Parameters["password"].ToString();

            var tryGetUser = userRepository.FirstOrDefault(user => user.Email == email && user.Password == password);
            if (tryGetUser == null)
            {
                var message = "User with this email is not exist!";
                var response = ResponseGenerator.GenerateErrorResponse(EventType.LoginErrorResponse, message);
                SocketInitializer.serverSocketManager.SendEvent(response);
            }
            else
            {
                var sucessResponseEvent = ResponseGenerator.GenerateSuccessResponse(EventType.LoginSuccessResponse, tryGetUser);
                SocketInitializer.serverSocketManager.SendEvent(sucessResponseEvent);
            }
        }

        public static void HandleRegister(Event eventParam)
        {
            DbAplicationContext registerContext = new DbAplicationContext();
            IUserRepository newUser = new UserRepository(registerContext);

            string email = eventParam.Parameters["email"].ToString();
            string nickname = eventParam.Parameters["nickname"].ToString();
            string password = eventParam.Parameters["password"].ToString();

            if (newUser.FirstOrDefault(user => user.Email == email) != null)
            {
                var message = "This user is already exist!";
                var responseEvent = ResponseGenerator.GenerateErrorResponse(EventType.RegisterErrorResponse, message);
                SocketInitializer.serverSocketManager.SendEvent(responseEvent);
            }
            else
            {
                User userEntity = new User { Email = email, Nickname = nickname, Password = password };

                newUser.Add(userEntity);
                registerContext.SaveChanges();
                var tryGetUsers = newUser.Find(user => user.Email != email);
                // create Dialogs with all existing users
                foreach (var existingUser in tryGetUsers)
                {
                    UserDialog userDialog1 = new UserDialog { User = userEntity, Dialog = new Dialog() };
                    UserDialog userDialog2 = new UserDialog { User = existingUser, Dialog = userDialog1.Dialog };

                    userEntity.UserDialogs.Add(userDialog1);
                    existingUser.UserDialogs.Add(userDialog2);

                    registerContext.SaveChanges();
                }
                registerContext.Dispose();

                var sucessResponseEvent = ResponseGenerator.GenerateSuccessResponse(EventType.RegisterSuccessResponse, userEntity);
                SocketInitializer.serverSocketManager.SendEvent(sucessResponseEvent);
            }
        }
    }
}
