using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class MenuRepo
    {
        private List<MenuPoco> _listOfItems = new List<MenuPoco>();

        //Create
        public void AddItemToList(MenuPoco item)
        {
            _listOfItems.Add(item);
        }

        //Read
        public List<MenuPoco> GetItemList()
        {
            return _listOfItems;
        }

        //Update
        public bool UpdateItemList(string oldMealName, MenuPoco newItem)
        {
            MenuPoco oldItem = GetItemByName(oldMealName);

            if(oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.MealDescription = newItem.MealDescription;
                oldItem.IngredientsList = newItem.IngredientsList;
                oldItem.MealPrice = newItem.MealPrice;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveItemFromList(string currentMealName)
        {
           MenuPoco currentItem = GetItemByName(currentMealName);

            if(currentItem == null)
            {
                return false;
            }

            int initialCount = _listOfItems.Count();
            _listOfItems.Remove(currentItem);

            if(initialCount > _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public MenuPoco GetItemByName(string name)
        {
            foreach(MenuPoco item in _listOfItems)
            {
                if(item.MealName.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}
