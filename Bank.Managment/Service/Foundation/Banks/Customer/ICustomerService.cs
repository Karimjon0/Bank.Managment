//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------


//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Managment.Service.Foundation.Banks.Customer
{
    internal interface ICustomerService
    {
        bool CreateClient(Customer customer);
        bool CreateClient(Models.Customer customer);
        bool DeleteClient(decimal accountNumber);

        bool TransferMoneyBetweenClients(
            decimal firstAccountNumber,
            decimal secondAccountNumber,
            decimal money);
    }
}