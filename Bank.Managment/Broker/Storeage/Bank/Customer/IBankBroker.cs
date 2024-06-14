
//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Management.Models;

namespace Bank.Management.Console.Brokers.Storages.Bank
{
    internal interface IBankBroker
    {
        bool MakingDeposit(decimal accountNumberForBank, decimal balance);
        decimal WithdrawMoney(decimal accountNumberForBank, decimal balance);
        decimal GetBalance(decimal accountNumberForBank);
    }
}
