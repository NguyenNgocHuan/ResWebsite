using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ResWebsite.DAL.Entity;

namespace ResWebsite.DAL.Implement
{
    public class MealDrinkImplement : IMealDrink
    {
        RestaurantDbContext db = new RestaurantDbContext();
        public void AddMealDrink(MealDrink mealDrink)
        {
            db.MealDrinks.Add(mealDrink);
            db.SaveChanges();
        }

        public bool DeleteMealDrink(string mealDrinkId)
        {
            db.MealDrinks.Remove(GetMealById(mealDrinkId));
            db.SaveChanges();
            return true;
        }

        public MealDrink GetMealById(string mealDrinkId)
        {
            try
            {
                return db.MealDrinks.Find(mealDrinkId);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public IEnumerable<MealDrink> GetAllMainDishes(List<MealDrink> mealList)
        {
            if (mealList == null)
                return db.MealDrinks.Where(x => x.MenuId.Equals(1) || x.MenuId.Equals(9) || x.MenuId.Equals(11));
            return mealList.Where(x => x.MenuId.Equals(1) || x.MenuId.Equals(9) || x.MenuId.Equals(11));
        }

        public IEnumerable<MealDrink> GetAllDessert(List<MealDrink> mealList)
        {
            if (mealList == null)
                return db.MealDrinks.Where(x => x.MenuId.Equals(13));
            return mealList.Where(x => x.MenuId.Equals(13));
        }

        public IEnumerable<MealDrink> GetAllFirstMeal(List<MealDrink> mealList)
        {
            if (mealList == null)
                return db.MealDrinks.Where(x => x.MenuId.Equals(7) || x.MenuId.Equals(8) || x.MenuId.Equals(10));
            return mealList.Where(x => x.MenuId.Equals(7) || x.MenuId.Equals(8) || x.MenuId.Equals(10));
        }

        public IEnumerable<MealDrink> GetAllDrink(List<MealDrink> mealList)
        {
            if (mealList == null)
                return db.MealDrinks.Where(x => x.MenuId.Equals(3) || x.MenuId.Equals(4) || x.MenuId.Equals(5));
            return mealList.Where(x => x.MenuId.Equals(3) || x.MenuId.Equals(4) || x.MenuId.Equals(5));
        }

        public IEnumerable<MealDrink> GetAllMealDrink(int contractId)
        {
            if (contractId.Equals(-1))
                return db.MealDrinks.ToList();
            return (from meal in db.MealDrinks
                    join detail in db.ReservationMealDrinkDetails
                    on meal.MealDrinkId equals detail.MealDrinkId
                    join contract in db.ReservationContracts
                    on detail.ReservationContractId equals contract.ReservationContractId
                    where (contract.ReservationContractId.Equals(contractId))
                    select meal).ToList();
        }

        public IEnumerable<MealDrink> GetMealByContractId(int contractId)
        {
            try
            {
                var query = (from meal in db.MealDrinks
                             join detail in db.ReservationMealDrinkDetails
                             on meal.MealDrinkId equals detail.MealDrinkId
                             join contract in db.ReservationContracts
                             on detail.ReservationContractId equals contract.ReservationContractId
                             where contract.ReservationContractId.Equals(contractId)
                             select meal).ToList();
                return query;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool UpdateMealDrink(MealDrink mealDrink)
        {
            throw new NotImplementedException();
        }

        public double GetTotalOfMealListDAL(int contractId, int quantityTable)
        {
            var list = GetAllMealDrink(contractId);
            double total = 0.0;
            foreach (var i in list)
            {
                total += (double)i.Price * quantityTable;
            }
            return total;
        }
        public IEnumerable<MealDrink> GetAllMealDrinkByOrderId(int orderId)
        {
            return (from meal in db.MealDrinks
                    join detail in db.OrderMealDrinkDetails
                    on meal.MealDrinkId equals detail.MealDrinkId
                    join order in db.Orders
                    on detail.OrderId equals order.OrderId
                    where (order.OrderId.Equals(orderId))
                    select meal).ToList();
        }
        public IEnumerable<MealDrink> GetAllMealDrinkByMenuId(int menuId)
        {
            return (from meal in db.MealDrinks
                    join menu in db.Menus
                    on meal.MenuId equals menu.MenuId
                    where (menu.MenuId.Equals(menuId))
                    select meal).ToList();
        }
        public IEnumerable<MealDrink> SearchMeal(string name)
        {
            return (from meal in db.MealDrinks
                    where (meal.Name.Contains(name))
                    select meal).ToList();
        }
    }
}
