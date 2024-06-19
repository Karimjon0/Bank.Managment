//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;
using Bank.Managment.Service.Foundation.Banks.Customer;
using Bank.Managment.Service.Foundation.Banks;

namespace Bank.Management.Console.Services.BankProcessing
{
    internal class BankProcessingsService : Services.BankProcessingsService.IBankProcessingsService
    {
        private readonly IRegistrService registrService;
        private readonly IBankService bankService;
        private readonly ICustomerService customerService;

        public BankProcessingsService(
            IRegistrService registrService,
            IBankService bankService,
            ICustomerService customerService)
        {
            this.registrService = registrService;
            this.bankService = bankService;
            this.customerService = customerService;
        }

        public bool DeleteForClient(decimal accountNumber) =>
            this.customerService.DeleteClient(accountNumber);

        public decimal GetBalance(decimal accountNumberForBank) =>
            this.bankService.GetBalanceInBank(accountNumberForBank);

        public decimal GetMoney(decimal accountNumberForBank, decimal balance) =>
            this.bankService.GetMoney(accountNumberForBank, balance);

        public bool LogInUser(Users user) =>
            this.registrService.LogIn(user);

        public bool PostDeposit(decimal accountNumberForBank, decimal balance) =>
        this.bankService.AddDeposit(accountNumberForBank, balance);

        public bool PostForClient(Customer customer) =>
            this.customerService.CreateClient(customer);

        public Users PostUser(Users user) =>
            this.registrService.SignUp(user);

        public bool TransferMoneyBetweenAccountsForClient(
            decimal firstAccountNumber,
            decimal secondAccountNumber,
            decimal money) =>
            this.customerService.TransferMoneyBetweenClients(
                            firstAccountNumber,
                            secondAccountNumber,
                            money);
    }

    public interface IRegistrService
    {
        bool LogIn(Users user);
        Users SignUp(Users user);
    }
}