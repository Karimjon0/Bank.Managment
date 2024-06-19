//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Management.Brokers.Loggings;
using Bank.Managment.Broker.Logging;
using Bank.Managment.Broker.Storeage.BankStoreage;

namespace Bank.Managment.Service.Foundation.Banks
{
    internal class BankService : IBankService
    {
        private readonly IBankBroker bankBroker;
        private readonly ILoggingBroker loggingBroker;

        public BankService()
        {
            bankBroker = new BankBroker();
            loggingBroker = new LoggingBroker();
        }

        public bool AddDeposit(decimal accountNumberForBank, decimal balance)
        {
            return accountNumberForBank is 0 || balance is 0
                ? InvalidAddDeposit()
                : ValidationAndAddDeposite(accountNumberForBank, balance);
        }

        public decimal GetBalanceInBank(decimal accountNumberForBank)
        {
            return accountNumberForBank is 0
                ? InvalidGetBalanceInBank()
                : ValidationAndGetBalanceInBank(accountNumberForBank);
        }

        public decimal GetMoney(decimal accountNumberForBank, decimal balance)
        {
            return accountNumberForBank is 0 || balance is 0
                    ? InvalidGetMoney()
                    : ValidationAndGetMoney(accountNumberForBank, balance);
        }

        private decimal ValidationAndGetMoney(decimal accountNumberForBank, decimal balance)
        {
            decimal resultWithdrawMoney =
                bankBroker.WithdrawMoney(accountNumberForBank, balance);

            if (resultWithdrawMoney is 0)
            {
                loggingBroker.LogError("Could not get balance.");
                return resultWithdrawMoney;
            }

            loggingBroker.LogInformation("Balance received successfully.");
            return resultWithdrawMoney;
        }

        private decimal InvalidGetMoney()
        {
            loggingBroker.LogError("The data entered is incomplete.");
            return 0;
        }

        private decimal ValidationAndGetBalanceInBank(
                decimal accountNumberForBank)
        {
            decimal resultGetBalance =
                bankBroker.GetBalance(accountNumberForBank);

            if (resultGetBalance == 0)
            {
                loggingBroker.LogError("Account number not found.");
                return resultGetBalance;
            }

            loggingBroker.LogInformation("Balance received successfully");
            return resultGetBalance;
        }

        private decimal InvalidGetBalanceInBank()
        {
            loggingBroker.LogError("Account number is incomplete.");
            return 0;
        }
        private bool ValidationAndAddDeposite(
            decimal accountNumberForBank,
            decimal balance)
        {
            bool resultMakingDeposite =
                bankBroker.MakingDeposit(accountNumberForBank, balance);
            if (resultMakingDeposite is true)
            {
                loggingBroker.LogInformation("Deposite added to bank account.");
                return resultMakingDeposite;
            }

            loggingBroker.LogError("Deposite not added to bank account.");
            return resultMakingDeposite;
        }

        private bool InvalidAddDeposit()
        {
            loggingBroker.
                LogError("The parameters required for Deposite are incomplete.");
            return false;
        }
    }
}