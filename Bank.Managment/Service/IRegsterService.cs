//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank.Managment.Models;

namespace Bank.Managment.Service
{
    internal interface IRegsterService
    {
        bool LogIn(Users user);
        Users SignUp(Users user);
    }
}
