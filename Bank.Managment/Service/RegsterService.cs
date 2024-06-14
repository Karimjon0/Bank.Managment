//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Broker.Logging;
using Bank.Managment.Broker.Storeage;
using Bank.Managment.Models;
using static Bank.Managment.Broker.Logging.LoggingBroker;
using static Bank.Managment.Broker.Storeage.StoreageBroker;
using static Bank.Managment.Service.RegsterService;

namespace Bank.Managment.Service
{
    internal class RegsterService
    {
        internal class RegisterService : IRegsterService
        {
            private readonly ILoggingBroker loggingBroker;
            private readonly IStoreageBroker registerBroker;
            public RegisterService()
            {
                this.loggingBroker = new Broker.Logging.LoggingBroker.LoggingBroker();
                this.registerBroker = new RegisterBroker();
            }
            public bool LogIn(Users user)
            {
                return user is null
                    ? InvalidLogInUser()
                    : ValidationAndLogIn(user);
            }
            public Users SignUp(Users user)
            {
                return user is null
                    ? InvalidSignUp()
                    : ValidationAndSignUpUser(user);
            }
            private Users InvalidSignUp()
            {
                this.loggingBroker.LogError("User information is null or empty.");
                return new Users();
            }
            private Users ValidationAndSignUpUser(Users user)
            {
                if (String.IsNullOrWhiteSpace(user.Name)
                    || String.IsNullOrWhiteSpace(user.Password))
                {
                    this.loggingBroker.LogError("User information is incomplete");
                    return new Users();
                }
                else
                {
                    Users userInformation = this.registerBroker.AddUser(user);

                    if (user.Password.Length >= 8)
                    {
                        if (userInformation is null)
                        {
                            this.loggingBroker.LogError("This user base is available.");
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
            private bool InvalidLogInUser()
            {
                this.loggingBroker.LogError("User data is null.");
                return false;
            }
            private bool ValidationAndLogIn(Users user)
            {
                if (String.IsNullOrWhiteSpace(user.Name)
                    || String.IsNullOrWhiteSpace(user.Password))
                {
                    this.loggingBroker.LogInformation("User data is not required.");
                    return false;
                }
                else
                {
                    bool isLogIn = this.registerBroker.GetUser(user);

                    if (user.Password.Length >= 8)
                    {
                        if (isLogIn is true)
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

            public bool LogIn(Users user)
            {
                throw new NotImplementedException();
            }

            public Users SignUp(Users user)
            {
                throw new NotImplementedException();
            }
        }
    }
}
