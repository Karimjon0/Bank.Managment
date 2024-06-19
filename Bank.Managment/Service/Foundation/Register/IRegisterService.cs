//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------


//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Managment.Service.Foundation.Register
{
    internal interface IRegisterService
    {
        bool LogIn(Users user);
        Users SignUp(Users user);
    }
}
