//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Management.Console.Services.Foundations.Banks;
using Bank.Management.Console.Services.Foundations.Customers;
using Bank.Managment.Models;
using Bank.Managment.Service.Foundation;
using Bank.Managment.Service.Foundation.Register;

namespace Bank.Management.Console.Services.BankProcessings
{
    internal class BankProcessingService : IBankProcessingService
    {
        private readonly IRegisterService registrService;
        private readonly IBankService bankService;
        private readonly ICustomerService customerService;
        private IBankService bankService1;

        public BankProcessingService(
            IRegisterService registrService,
            IBankService bankService,
            ICustomerService customerService)
        {
            this.registrService = registrService;
            this.bankService = bankService;
            this.customerService = customerService;
        }

        public bool DeleteForClient(decimal accountNumber) =>
            this.customerService.DeleteClient(accountNumber);

        public string GetAllClient() => this.customerService.GetAllCustomer();

        public decimal GetBalance(decimal accountNumberForBank) =>
            this.bankService.GetBalanceInBank(accountNumberForBank);

        public decimal GetBalanceClient(decimal accountNumber) =>
            this.customerService.GetBalanceInClient(accountNumber);

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
}
