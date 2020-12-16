using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class MenuPoco
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string IngredientsList { get; set; }
        public double MealPrice { get; set; }

        public MenuPoco() { }
        public MenuPoco(int mealNumber, string mealName, string mealDescription, string ingredientsList, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            IngredientsList = ingredientsList;
            MealPrice = mealPrice;
        }
    }
}
