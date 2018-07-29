using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Implement
{
    public class ItemImplement : IItem
    {
        RestaurantDbContext db = null;
        public ItemImplement()
        {
            db = new RestaurantDbContext();
        }
        public IEnumerable<Item> GetAllItem()
        {
            return db.Items.ToList();
        }
        public bool AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public Item FindItem(int itemId)
        {
            throw new NotImplementedException();
        }
       

        public bool UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
