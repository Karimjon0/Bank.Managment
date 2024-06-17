
//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Management.Console.Brokers.Storages.BankStorage.Customers
{
    internal interface ICustomerBroker
    {
        bool CreateAccountNumberForClient(Customer customer);
        bool CloseAccountNumberForClient(decimal accountNumber);
        bool TransferMoneyBetweenAccounts(decimal firstAccountNumber, decimal secondAccountNumber, decimal money);
    }
}
