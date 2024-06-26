﻿//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Management.Console.Services.Foundations.Customers
{
    internal interface ICustomerService
    {
        bool CreateClient(Customer customer);
        bool DeleteClient(decimal accountNumber);

        bool TransferMoneyBetweenClients(
            decimal firstAccountNumber,
            decimal secondAccountNumber,
            decimal money);

        string GetAllCustomer();
        decimal GetBalanceInClient(decimal accountNumber);
    }
}