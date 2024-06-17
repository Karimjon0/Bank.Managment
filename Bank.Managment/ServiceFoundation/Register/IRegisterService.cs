//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Managment.ServiceFoundation.Register
{
    internal interface IRegisterService
    {
        bool LogIn(Users user);
        Users SignUp(Users user);
    }
}
