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
                var message = "User with this email is not registered exist!";
                var response = ResponseGenerator.GenerateErrorResponse(EventType.LoginErrorResponse, message);
                SocketInitializer.serverSocketManager.SendEvent(response);
            }
            else
            {
                var sucessResponseEvent = ResponseGenerator.GenerateSucessResponse(EventType.LoginSucessResponse, tryGetUser);
                SocketInitializer.serverSocketManager.SendEvent(sucessResponseEvent);
            }
        }

        public static void HandleRegister(Event eventParam)
        {
            DbAplicationContext registerContext = new DbAplicationContext();
            IUserRepository newUser = new UserRepository(registerContext);

            string email = eventParam.Parameters["email"].ToString();
            string password = eventParam.Parameters["password"].ToString();

            if (newUser.FirstOrDefault(user => user.Email == email) != null)
            {
                var message = "This user is already exist!";
                var responseEvent = ResponseGenerator.GenerateErrorResponse(EventType.RegisterResponse, message);
                SocketInitializer.serverSocketManager.SendEvent(responseEvent);
            }
            else
            {
                User userEntity = new User { Email = email, Password = password };

                newUser.Add(userEntity);
                registerContext.SaveChanges();
                registerContext.Dispose();

                var sucessResponseEvent = ResponseGenerator.GenerateSucessResponse(EventType.RegisterRedirect, userEntity);
                SocketInitializer.serverSocketManager.SendEvent(sucessResponseEvent);
            }
        }
    }
}
