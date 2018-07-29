using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IMealDrink
    {
        IEnumerable<MealDrink> GetAllMealDrink(int contractId);
        void AddMealDrink(MealDrink mealDrink);
        bool UpdateMealDrink(MealDrink mealDrink);
        bool DeleteMealDrink(string mealDrinkId);
        MealDrink GetMealById(string mealDrinkId);
        IEnumerable<MealDrink> GetMealByContractId(int contractId);
        IEnumerable<MealDrink> GetAllFirstMeal(List<MealDrink> mealList);
        IEnumerable<MealDrink> GetAllDessert(List<MealDrink> mealList);
        IEnumerable<MealDrink> GetAllMainDishes(List<MealDrink> mealList);
        IEnumerable<MealDrink> GetAllDrink(List<MealDrink> mealList);
        double GetTotalOfMealListDAL(int contractId, int quantityTable);
        }
}
