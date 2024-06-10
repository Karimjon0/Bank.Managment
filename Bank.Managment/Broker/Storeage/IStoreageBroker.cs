//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Managment.Broker.Storeage
{
    internal interface IStoreageBroker
    {
        Users AddUser(Users user);
        bool GetUser(Users user);
        bool LogIn(Users user);
    }
}
