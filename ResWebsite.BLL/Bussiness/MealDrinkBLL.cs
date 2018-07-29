using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Implement;

namespace ResWebsite.BLL.Bussiness
{
    public class MealDrinkBLL
    {
        MealDrinkImplement dal = new MealDrinkImplement();

        public IEnumerable<MealDrink> GetAllMeal(int contractId)
        {
            return dal.GetAllMealDrink(contractId);
        }

        public IEnumerable<MealDrink> GetAllMainDishes(List<MealDrink> mealList)
        {
            return dal.GetAllMainDishes(mealList);
        }

        public IEnumerable<MealDrink> GetAllDessert(List<MealDrink> mealList)
        {
            return dal.GetAllDessert(mealList);
        }

        public IEnumerable<MealDrink> GetAllFirstMeal(List<MealDrink> mealList)
        {
            return dal.GetAllFirstMeal(mealList);
        }

        public MealDrink GetMealById(string id)
        {
            return dal.GetMealById(id);
        }

        public IEnumerable<MealDrink> GetAllDrink(List<MealDrink> mealList)
        {
            return dal.GetAllDrink(mealList);
        }
        public double GetTotalOfMealListBLL(int contractId, int quantityClient)
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
            if (contractId > 0)
                return dal.GetTotalOfMealListDAL(contractId, quantityTable);
            return 0.0;
        }
        public IEnumerable<MealDrink> GetAllMealDrinkByOrderId(int orderId)
        {
            if (orderId > 0)
                return dal.GetAllMealDrinkByOrderId(orderId);
            return null;
        }
        public IEnumerable<MealDrink> GetAllMealDrinkByMenuIdBLL(int menuId)
        {
            return dal.GetAllMealDrinkByMenuId(menuId);
        }
        public IEnumerable<MealDrink> SearchMealBLL(string name)
        {
            return dal.SearchMeal(name);
        }
    }
}
