
//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Management.Brokers.Loggings;
using Bank.Management.Console.Brokers.Storages;
using Bank.Management.Console.Brokers.Storages.RegistrsStorage;
using Bank.Managment.Broker.Logging;
using Bank.Managment.Models;
using Bank.Managment.Service.Foundation.Register;

namespace Bank.Management.Console.Services.Foundations.Registrs
{
    internal class RegistrService : IRegisterService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IRegistrBroker registrBroker;

        public RegistrService()
        {
            this.loggingBroker = new LoggingBroker();
            this.registrBroker = new RegistrBroker();
        }

        public bool LogIn(Users user)
        {
            return user is null
                ? InvalidLogInUser()
                : ValidationAndLogInUser(user);
        }

        public Users SignUp(Users user)
        {
            return user is null
                ? InvalidSignUpUser()
                : ValidationAndSignUpUser(user);
        }

        private Users ValidationAndSignUpUser(Users user)
        {
            if (String.IsNullOrWhiteSpace(user.Name)
                || String.IsNullOrWhiteSpace(user.Password))
            {
                this.loggingBroker.LogError("User information is incomplete.");
                return new Users();
            }
            else
            {
                Users userInformation = this.registrBroker.AddUser(user);

                if (user.Password.Length >= 8)
                {
                    if (userInformation.Name is null)
                    {
                        this.loggingBroker.LogError("This user is available in the database.");
                        return new Users();
                    }
                    else
                    {
                        this.loggingBroker.LogInformation("User added successfully.");
                        return user;
                    }
                }
                else
                {
                    this.loggingBroker.LogError("Password does not contain 8 characters.");
                    return new Users();
                }
            }
        }

        private Users InvalidSignUpUser()
        {
            this.loggingBroker.LogError("User information is null or empty.");
            return new Users();
        }

        private bool ValidationAndLogInUser(Users user)
        {
            if (String.IsNullOrWhiteSpace(user.Name)
                || String.IsNullOrWhiteSpace(user.Password))
            {
                this.loggingBroker.LogInformation("User data is not required.");
                return false;
            }
            else
            {
                bool IsLogIn = this.registrBroker.CheckoutUser(user);

                if (user.Password.Length >= 8)
                {
                    if (IsLogIn is true)
                    {
                        this.loggingBroker.LogInformation("Successfully logged in.");
                        return true;
                    }
                    else
                    {
                        this.loggingBroker.LogError("User does not exist in the database.");
                        return false;
                    }
                }
                else
                {
                    this.loggingBroker.LogError("Password does not contain 8 characters.");
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
