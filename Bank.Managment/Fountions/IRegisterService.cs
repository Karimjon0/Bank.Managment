﻿using Bank.Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Managment.Fountions
{
    internal interface IRegisterService
    {
        bool LogIn(Users user);
        Users SignUp(Users user);
    }
}
