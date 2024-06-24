//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Management.Brokers.Loggings;
using Bank.Management.Console.Brokers.Storages.RegistrsStorage;
using Bank.Managment.Broker.Logging;
using Bank.Managment.Models;
using System.Runtime.InteropServices;

namespace Bank.Managment.Service.Foundation.Register
{
    internal class RegisterService : IRegisterService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IRegistrBroker registrBroker;

        public RegisterService()
        {
            loggingBroker = new LoggingBroker();
            registrBroker = new RegistrBroker();
        }
        public bool LogIn(Users user)
        {
            return user is null
                ? InvalidLogInUser()
                : LogInUserValidation(user);
        }

        public Users SignUp(Users user)
        {
            return user is null
            ? InvalidSignUpUser()
                : SignUpUserAndValidation(user);
        }

        private Users SignUpUserAndValidation(Users user)
        {
            if (string.IsNullOrWhiteSpace(user.Name)
                || string.IsNullOrWhiteSpace(user.Password))
            {
                loggingBroker.LogError("User information is incomplete");
                return new Users();
            }
            else
            {
                Users userInformation = registrBroker.AddUser(user);

                if (user.Password.Length >= 8)
                {
                    if (userInformation is null)
                    {
                        loggingBroker.LogError("This user base is available.");
                        return new Users();
                    }
                    else
                    {
                        loggingBroker.LogInformation("User added successfully.");
                        return user;
                    }
                }
                else
                {
                    loggingBroker.LogError("Password does not contain 8 characters.");
                    return new Users();
                }
            }
        }

        private Users InvalidSignUpUser()
        {
            loggingBroker.LogError("User information is null or empty.");
            return new Users();
        }

        private bool LogInUserValidation(Users user)
        {
            if (string.IsNullOrWhiteSpace(user.Name)
                || string.IsNullOrWhiteSpace(user.Password))
            {
                loggingBroker.LogInformation("User data is not required.");
                return false;
            }
            else
            {
                bool isLogIn = registrBroker.LogIn(user);

                if (user.Password.Length >= 8)
                {
                    if (isLogIn is true)
                    {
                        loggingBroker.LogInformation("Successfully logged in.");
                        return true;
                    }
                    else
                    {
                        loggingBroker.LogError("User does not exist in the database.");
                        return false;
                    }
                }
                else
                {
                    loggingBroker.LogError("Password does not contain 8 characters.");
                    return false;
                }
            }
        }

        private bool InvalidLogInUser()
        {
            this.loggingBroker.LogError("User data is null.");
            return false;
        }
    }
}