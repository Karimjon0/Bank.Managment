﻿//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

namespace Bank.Managment.ServiceFoundation.Banks
{
    internal interface IBankService
    {
        bool AddDeposit(decimal accountNumberForBank, decimal balance);
        decimal GetMoney(decimal accountNumberForBank, decimal balance);
        decimal GetBalanceInBank(decimal accountNumberForBank);
    }
}
