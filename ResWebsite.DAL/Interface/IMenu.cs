using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IMenu
    {
        IEnumerable<Menu> GetAllMenu();
        bool AddMenu(Menu menu);
        bool UpdateMenu(Menu menu);
        bool DeleteMenu(int menuId);
        Menu FindMenu(int menuId);
    }
}
