using System;
using System.Collections.Generic;
using System.Linq;
using ResWebsite.DAL.Entity1;

namespace ResWebsite.DAL.DAL
{
    public class MonAnThucUongDAL : RepositoryBase<MonAnThucUong>
    {

        public MonAnThucUongDAL(ResDbContext _db) : base(_db)
        {
        }
        public IEnumerable<MonAnThucUong> TimKiemGanDungTheoTen(string thongTin)
        {
            return db.MonAnThucUongs.Where(x => x.TenMonAnThucUong.Contains(thongTin));
        }

        public IEnumerable<MonAnThucUong> LayTatCaMonAn()
        {
            return db.MonAnThucUongs.Where(x => x.PhanLoai.Equals("Món ăn"));
        }

        public IEnumerable<MonAnThucUong> LayTatCaThucUong()
        {
            return db.MonAnThucUongs.Where(x => x.PhanLoai.Equals("Thức uống"));
        }
        public void AddMealDrink(MonAnThucUong mealDrink)
            {
                db.MonAnThucUongs.Add(mealDrink);
                db.SaveChanges();
            }

            public bool DeleteMealDrink(string mealDrinkId)
            {
                db.MonAnThucUongs.Remove(GetMealById(mealDrinkId));
                db.SaveChanges();
                return true;
            }

            public MonAnThucUong GetMealById(string mealDrinkId)
            {
                try
                {
                    return db.MonAnThucUongs.Find(mealDrinkId);
                }
                catch (Exception)
                {
                    return null;
                    throw;
                }
            }

            //public IEnumerable<MonAnThucUong> GetAllMainDishes(List<MonAnThucUong> mealList)
            //{
            //    if (mealList == null)
            //        return db.MonAnThucUongs.Where(x => x.MaThucDon.Equals("1") || x.MaThucDon.Equals("9") || x.MaThucDon.Equals("11"));
            //    return mealList.Where(x => x.MaThucDon.Equals("1") || x.MaThucDon.Equals("9") || x.MaThucDon.Equals("11"));
            //}

            //public IEnumerable<MonAnThucUong> GetAllDessert(List<MonAnThucUong> mealList)
            //{
            //    if (mealList == null)
            //        return db.MonAnThucUongs.Where(x => x.MaThucDon.Equals("13"));
            //    return mealList.Where(x => x.MaThucDon.Equals("13"));
            //}

            //public IEnumerable<MonAnThucUong> GetAllFirstMeal(List<MonAnThucUong> mealList)
            //{
            //    if (mealList == null)
            //        return db.MonAnThucUongs.Where(x => x.MaThucDon.Equals("7") || x.MaThucDon.Equals("8") || x.MaThucDon.Equals("10"));
            //    return mealList.Where(x => x.MaThucDon.Equals("7") || x.MaThucDon.Equals("8") || x.MaThucDon.Equals("10"));
            //}

            //public IEnumerable<MonAnThucUong> GetAllDrink(List<MonAnThucUong> mealList)
            //{
            //    if (mealList == null)
            //        return db.MonAnThucUongs.Where(x => x.MaThucDon.Equals("3") || x.MaThucDon.Equals("4") || x.MaThucDon.Equals("5"));
            //    return mealList.Where(x => x.MaThucDon.Equals("3") || x.MaThucDon.Equals("4") || x.MaThucDon.Equals("5"));
            //}

            public IEnumerable<MonAnThucUong> GetAllMealDrink(string contractId)
            {
                if (contractId.Equals("-1"))
                    return db.MonAnThucUongs.ToList();
                return (from meal in db.MonAnThucUongs
                        join detail in db.ChiTietDatTiecMonAnThucUongs
                        on meal.MaMonAnThucUong equals detail.MaMonAnThucUong
                        join contract in db.HopDongDatTiecs
                        on detail.MaHopDongDatTiec equals contract.MaHopDongDatTiec
                        where (contract.MaHopDongDatTiec.Equals(contractId))
                        select meal).ToList();
            }

            public IEnumerable<MonAnThucUong> GetMealByContractId(string contractId)
            {
                try
                {
                    var query = (from meal in db.MonAnThucUongs
                                 join detail in db.ChiTietDatTiecMonAnThucUongs
                                 on meal.MaMonAnThucUong equals detail.MaMonAnThucUong
                                 join contract in db.HopDongDatTiecs
                                 on detail.MaHopDongDatTiec equals contract.MaHopDongDatTiec
                                 where contract.MaHopDongDatTiec.Equals(contractId)
                                 select meal).ToList();
                    return query;
                }
                catch (Exception)
                {

                    throw;
                }

            }

            public bool UpdateMealDrink(MonAnThucUong mealDrink)
            {
                throw new NotImplementedException();
            }

            public double GetTotalOfMealListDAL(string contractId, int quantityTable)
            {
                var list = GetAllMealDrink(contractId);
                double total = 0.0;
                foreach (var i in list)
                {
                    total += (double)i.DonGia * quantityTable;
                }
                return total;
            }
            public IEnumerable<MonAnThucUong> GetAllMealDrinkByOrderId(string orderId)
            {
                return (from meal in db.MonAnThucUongs
                        join detail in db.ChiTietGoiMonMonAnThucUongs
                        on meal.MaMonAnThucUong equals detail.MaMonAnThucUong
                        join order in db.HoaDonGoiMons
                        on detail.MaHoaDonGoiMon equals order.MaHoaDonGoiMon
                        where (order.MaHoaDonGoiMon.Equals(orderId))
                        select meal).ToList();
            }
        //public IEnumerable<MonAnThucUong> GetAllMealDrinkByMenuId(string menuId)
        //{
        //    return (from meal in db.MonAnThucUongs
        //            join menu in db.ThucDons
        //            on meal.MaThucDon equals menu.MaThucDon
        //            where (menu.MaThucDon.Equals(menuId))
        //            select meal).ToList();
        //}
    }
    }
