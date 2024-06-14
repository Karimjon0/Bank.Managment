using Bank.Managment.Broker.Logging;
using Bank.Managment.Broker.Storeage.RegisterStoreage;
using Bank.Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank.Managment.Broker.Logging.LoggingBroker;
using static Bank.Managment.Broker.Storeage.RegisterStoreage.StoreageBroker;

namespace Bank.Managment.Fountions
{
    internal class RegiterService
    {
        internal class RegistrService : IRegisterService
        {
            private readonly ILoggingBroker loggingBroker;
            private readonly IStoreageBroker registrBroker;

            public RegistrService()
            {
                this.loggingBroker = new Broker.Logging.LoggingBroker.LoggingBroker();
                this.registrBroker = new RegisterBroker();
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
                if (String.IsNullOrWhiteSpace(user.Name)
                    || String.IsNullOrWhiteSpace(user.Password))
                {
                    this.loggingBroker.LogError("User information is incomplete");
                    return new Users();
                }
                else
                {
                    Users userInformation = this.registrBroker.AddUser(user);

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

            private Users InvalidSignUpUser()
            {
                this.loggingBroker.LogError("User information is null or empty.");
                return new Users();
            }

            private bool LogInUserValidation(Users user)
            {
                if (String.IsNullOrWhiteSpace(user.Name)
                    || String.IsNullOrWhiteSpace(user.Password))
                {
                    this.loggingBroker.LogInformation("User data is not required.");
                    return false;
                }
                else
                {
                    bool isLogIn = this.registrBroker.LogIn(user);

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

            private bool InvalidLogInUser()
            {
                this.loggingBroker.LogError("User data is null.");
                return false;
            }
        }
    }
}
