
namespace ResWebsite.DAL.ObjectModel
{
    public class ItemObject
    {
        public string id { set; get; } 
        public string Name { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public string note { set; get; }
        public int orderId { set; get; }
        public ItemObject()
        {

        }
    }
}

