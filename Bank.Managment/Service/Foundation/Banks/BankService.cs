
//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Management.Brokers.Loggings;
using Bank.Managment.Broker.Logging;
using Bank.Managment.Service.Foundation.Banks;

namespace Bank.Management.Console.Services.Foundations.Banks
{
    internal class BankService : IBankService
    {
        private readonly IBankStoreageBroker bankBroker;
        private readonly ILoggingBroker loggingBroker;

        public IBankStoreageBroker BankBroker => bankBroker;

        public BankService()
        {
            this.bankBroker = new BankStoreageBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public bool AddDeposit(decimal accountNumberForBank, decimal balance)
        {
            return (accountNumberForBank is 0 || balance is 0)
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
            return (accountNumberForBank is 0 || balance is 0)
                    ? InvalidGetMoney()
                    : ValidationAndGetMoney(accountNumberForBank, balance);
        }

        private decimal ValidationAndGetMoney(decimal accountNumberForBank, decimal balance)
        {
            decimal resultWithdrawMoney =
                this.BankBroker.WithdrawMoney(accountNumberForBank, balance);

            if (resultWithdrawMoney is 0)
            {
                this.loggingBroker.LogError("Could not get balance.");
                return resultWithdrawMoney;
            }

            this.loggingBroker.LogInformation("Balance received successfully.");
            return resultWithdrawMoney;
        }

        private decimal InvalidGetMoney()
        {
            this.loggingBroker.LogError("The data entered is incomplete.");
            return 0;
        }

        private decimal ValidationAndGetBalanceInBank(
                decimal accountNumberForBank)
        {
            decimal resultGetBalance =
                this.BankBroker.GetBalance(accountNumberForBank);

            if (resultGetBalance == 0)
            {
                this.loggingBroker.LogError("Account number not found.");
                return resultGetBalance;
            }

            this.loggingBroker.LogInformation("Balance received successfully");
            return resultGetBalance;
        }

        private decimal InvalidGetBalanceInBank()
        {
            this.loggingBroker.LogError("Account number is incomplete.");
            return 0;
        }
        private bool ValidationAndAddDeposite(
            decimal accountNumberForBank,
            decimal balance)
        {
            bool resultMakingDeposite =
                this.BankBroker.MakingDeposit(accountNumberForBank, balance);
            if (resultMakingDeposite is true)
            {
                this.loggingBroker.LogInformation("Deposite added to bank account.");
                return resultMakingDeposite;
            }

            this.loggingBroker.LogError("Deposite not added to bank account.");
            return resultMakingDeposite;
        }

        private bool InvalidAddDeposit()
        {
            this.loggingBroker.
                LogError("The parameters required for Deposite are incomplete.");
            return false;
        }
    }

    internal class BankStoreageBroker : IBankStoreageBroker
    {
        public decimal GetBalance(decimal accountNumberForBank)
        {
            throw new NotImplementedException();
        }

        public bool MakingDeposit(decimal accountNumberForBank, decimal balance)
        {
            throw new NotImplementedException();
        }

        public decimal WithdrawMoney(decimal accountNumberForBank, decimal balance)
        {
            throw new NotImplementedException();
        }
    }

    internal interface IBankStoreageBroker
    {
        decimal GetBalance(decimal accountNumberForBank);
        bool MakingDeposit(decimal accountNumberForBank, decimal balance);
        decimal WithdrawMoney(decimal accountNumberForBank, decimal balance);
    }
}
