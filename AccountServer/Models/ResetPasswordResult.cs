using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Models
{
    public enum ResetPasswordResult
    {
        Success = 0,
        NewPasswordNotValid = 1,
        AccountInfoNotValid = 2
    }
}
