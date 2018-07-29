using System.Collections.Generic;
using ResWebsite.DAL.Entity1;
using ResWebsite.DAL.DAL;


namespace ResWebsite.BLL.BLL
{
    public class ThucAnThucUongBLL
    {
            MonAnThucUongDAL dal = new MonAnThucUongDAL(new ResDbContext());

            public IEnumerable<MonAnThucUong> GetAllMeal(string contractId)
            {
                return dal.GetAllMealDrink(contractId);
            }

            public IEnumerable<MonAnThucUong> GetAllMainDishes(List<MonAnThucUong> mealList)
            {
            //return dal.GetAllMainDishes(mealList);
            return null;
            }

            public IEnumerable<MonAnThucUong> GetAllDessert(List<MonAnThucUong> mealList)
            {
            // return dal.GetAllDessert(mealList);
            return null;
        }

            public IEnumerable<MonAnThucUong> GetAllFirstMeal(List<MonAnThucUong> mealList)
            {
                //return dal.GetAllFirstMeal(mealList);
            return null;
        }

            public MonAnThucUong GetMealById(string id)
            {
                return dal.GetMealById(id);
            }

            public IEnumerable<MonAnThucUong> GetAllDrink(List<MonAnThucUong> mealList)
            {
            //return dal.GetAllDrink(mealList);
            return null;
        }
            public double GetTotalOfMealListBLL(string contractId, int quantityClient)
            {
                int quantityTable = 0;
                if (quantityClient % 10 == 0)
                {
                    quantityTable = quantityClient / 10;
                }
                else if (quantityClient % 10 > 0)
                {
                    quantityTable = quantityClient / 10;
                    quantityTable += 1;
                }
                if (!contractId.Equals(""))
                    return dal.GetTotalOfMealListDAL(contractId, quantityTable);
                return 0.0;
            }
            public IEnumerable<MonAnThucUong> GetAllMealDrinkByOrderId(string orderId)
            {
                if (!orderId.Equals(""))
                    return dal.GetAllMealDrinkByOrderId(orderId);
                return null;
            }
            public IEnumerable<MonAnThucUong> GetAllMealDrinkByMenuIdBLL(string menuId)
            {
            //return dal.GetAllMealDrinkByMenuId(menuId);
            return null;
        }
        }
    }

