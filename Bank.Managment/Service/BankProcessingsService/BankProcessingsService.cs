
//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;
using Bank.Managment.Service.Foundation.Banks;
using Bank.Management.Console.Services.BankProcessingsService;
using Bank.Managment.Service.Foundation.Register;
using Bank.Management.Console.Services.Foundations.Customers;

namespace Bank.Management.Console.Services.BankProcessings
{
    internal class BankProcessingService : IBankProcessingsService
    {
        private readonly IRegisterService registrService;
        private readonly IBankService bankService;
        private readonly ICustomerService customerService;
        private ICustomerService customerService1;

        public BankProcessingService(
            IRegisterService registrService,
            IBankService bankService,
            ICustomerService customerService)
        {
            this.registrService = registrService;
            this.bankService = bankService;
            this.customerService = customerService;
        }

        public BankProcessingService(IRegisterService registrService, IBankService bankService, ICustomerService customerService1)
        {
            this.registrService = registrService;
            this.bankService = bankService;
            this.customerService1 = customerService1;
        }

        public bool DeleteForClient(decimal accountNumber) =>
            this.customerService.DeleteClient(accountNumber);

        public decimal GetBalance(decimal accountNumberForBank) =>
            this.bankService.GetBalanceInBank(accountNumberForBank);

        public decimal GetMoney(decimal accountNumberForBank, decimal balance) =>
            this.bankService.GetMoney(accountNumberForBank, balance);

        public bool LogInUser(Users user) =>
            this.registrService.LogIn(user);

        public bool LogInUsers(Users user) => throw new NotImplementedException();

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

        internal void GetAllClient()
        {
            throw new NotImplementedException();
        }

        internal decimal GetBalanceClient(decimal accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
