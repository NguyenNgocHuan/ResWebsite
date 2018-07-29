using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    interface IAccount_Log
    {
        IEnumerable<Account_Log> GetAllAccount_Log(int page, int pageSize);
        IEnumerable<Account_Log> GetAllAccount_Log(DateTime dateTime, int page, int pageSize);
    }
}
