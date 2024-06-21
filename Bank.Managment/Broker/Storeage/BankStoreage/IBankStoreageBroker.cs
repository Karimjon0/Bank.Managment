
//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Managment.Broker.Storeage.BankStoreage
{
    internal interface IBankBroker
    {
        bool MakingDeposit(decimal accountNumberForBank, decimal balance);
        decimal WithdrawMoney(decimal accountNumberForBank, decimal balance);
        decimal GetBalance(decimal accountNumberForBank);
    }
}
