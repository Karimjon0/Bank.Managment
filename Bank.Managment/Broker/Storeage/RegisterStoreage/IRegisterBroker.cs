//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Management.Console.Brokers.Storages.RegistrsStorage
{
    internal interface IRegistrBroker
    {
        Users AddUser(Users user);
        bool CheckoutUser(Users user);
    }
}