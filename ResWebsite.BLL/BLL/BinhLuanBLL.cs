using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.DAL;
using System.Collections.Generic;

namespace ResWebsite.BLL.BLL
{
    public class BinhLuanBLL
    {
        BinhLuanDAL dal = new BinhLuanDAL();
        public bool AddBinhLuanBLL(BinhLuan binhLuan)
        {
            if (binhLuan != null)
            {
                dal.AddBinhLuan(binhLuan);
                return true;
            }
            return false;
        }
        public IEnumerable<BinhLuan> GetAllBinhLuanBLL()
        {
            return dal.GetAllBinhLuan();
        }
    }
}
