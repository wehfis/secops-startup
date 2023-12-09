using Azure;
using BLL.Core.Domain;
using BLL.Core.Repositories;
using DAL.DBContex;
using DAL.Persistence.Repositories;

namespace MessangerServer.SocketLogic
{
    public static class AuthenticationHandler
    {

        public static void HandleLogin(Event eventParam)
        {
            // get email + password from eventParam dictionary
            // handle login with checking data base for this user
            DbAplicationContext loginContext = new DbAplicationContext();
            IUserRepository existingUser = new UserRepository(loginContext);

            string email = eventParam.Parameters["email"].ToString();
            string password = eventParam.Parameters["password"].ToString();

            if (existingUser.FirstOrDefault(user => user.Username == email) == null)
            {
                // return Response;
            }
            // return Response (redirect to main page)
        }

        public static void HandleRegister(Event eventParam)
        {
            DbAplicationContext registerContext = new DbAplicationContext();
            IUserRepository newUser = new UserRepository(registerContext);

            string email = eventParam.Parameters["email"].ToString();
            string password = eventParam.Parameters["password"].ToString();

            if (newUser.FirstOrDefault(user => user.Username == email) != null)
            {
                // return Response;
            }

            User userEntity = new User { Username = email, Password = password, Role = UserRole.User };

            newUser.Add(userEntity);
            registerContext.SaveChanges();
            registerContext.Dispose();
            // return Response;

        }
    }
}
