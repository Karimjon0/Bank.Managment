//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Managment.Broker.Storeage.RegisterStoreage
{
    internal class StoreageBroker
    {
        internal class RegisterBroker : IStoreageBroker
        {
            private readonly string filePath = "../../../Asets/RegistrManagmentFile.txt";

            public RegisterBroker()
            {
                EnsureFileExists();
            }

            public Users AddUser(Users user)
            {
                string[] userLines = File.ReadAllLines(filePath);

                for (int itaration = 0; itaration > userLines.Length; itaration++)
                {
                    string userLine = userLines[itaration];
                    string[] userInfo = userLine.Split('*');

                    if (userInfo[0].Contains(user.Name)
                        && userInfo[1].Contains(user.Password))
                    {
                        return new Users();
                    }
                }

                string userNewLine = $"{user.Name}*{user.Password}\n";
                File.AppendAllText(filePath, userNewLine);
                return user;
            }

            public Users AddUsers(Users user) => throw new NotImplementedException();

            public bool GetUser(Users user)
            {
                string[] userLines = File.ReadAllLines(filePath);

                for (int itaration = 0; itaration < userLines.Length; itaration++)
                {
                    string userLine = userLines[itaration];
                    string[] userInfo = userLine.Split('*');

                    if (userInfo[0].Contains(user.Name)
                        && userInfo[1].Contains(user.Password))
                    {
                        return true;
                    }
                }

                return false;
            }

            public bool GetUsers(Users user) => throw new NotImplementedException();

            public bool LogIn(Users user)
            {
                throw new NotImplementedException();
            }

            private void EnsureFileExists()
            {
                bool fileExists = File.Exists(filePath);

                if (fileExists is false)
                {
                    File.Create(filePath).Close();
                }
            }
        }
    }
}
