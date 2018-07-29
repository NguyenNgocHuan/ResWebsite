using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IItem
    {
        IEnumerable<Item> GetAllItem();
        bool AddItem(Item item);
        bool UpdateItem(Item item);
        bool DeleteItem(int itemId);
        Item FindItem(int itemId);
    }
}
