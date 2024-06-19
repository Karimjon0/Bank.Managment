//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Management.Console.Services.BankProcessingsService
{
    internal interface IBankProcessingsService
    {
        public bool DeleteForClient(decimal accountNumber);
        public decimal GetBalance(decimal accountNumberForBank);
        public decimal GetMoney(decimal accountNumberForBank, decimal balance);
        public bool LogInUser(Users user);
        public bool PostDeposit(decimal accountNumberForBank, decimal balance);
        public bool PostForClient(Customer customer);
        public Users PostUser(Users user);
        public bool TransferMoneyBetweenAccountsForClient(
                decimal firstAccountNumber,
                decimal secondAccountNumber,
                decimal money);
    }
}
