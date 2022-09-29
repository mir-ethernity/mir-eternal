using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Models
{
    public enum ChangePasswordResult
    {
        Success = 0,
        AccountNotExistsOrWrongPassword = 1
    }
}
