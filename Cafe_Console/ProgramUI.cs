using GoldBadgeConsoleAppChallenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    class ProgramUI
    {
        private MenuRepo _itemRepo = new MenuRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Choose a selection:\n" +
                    "1. Create new item\n" +
                    "2. View all items\n" +
                    "3. View item by name\n" +
                    "4. Update existing items\n" +
                    "5. Delete existing items\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewItem();
                        break;
                    case "2":
                        ViewAllItems();
                        break;
                    case "3":
                        ViewItemByName();
                        break;
                    case "4":
                        UpdateExistingItems();
                        break;
                    case "5":
                        DeleteExistingItems();
                        break;
                    case "6":
                        Console.WriteLine("Bonne journée mon ami!!");
                        keepRunning = false;
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewItem()
        {
            Console.Clear();
            MenuPoco newItem = new MenuPoco();

            Console.WriteLine("Enter the item's name:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the item's number:");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);

            Console.WriteLine("Enter the item's description:");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the item's list of ingredients:");
            newItem.IngredientsList = Console.ReadLine();

            Console.WriteLine("Enter the item's price:");
            string mealPriceAsString = Console.ReadLine();
            newItem.MealPrice = double.Parse(mealPriceAsString);

            _itemRepo.AddItemToList(newItem);

        }

        private void ViewAllItems()
        {
            Console.Clear();

            List<MenuPoco> listOfItems = _itemRepo.GetItemList();

            foreach (MenuPoco item in listOfItems)
            {
                Console.WriteLine($"Name: {item.MealName}\n" +
                    $"Description: {item.MealDescription}");
            }

        }

        private void ViewItemByName()
        {
            Console.Clear();

            Console.WriteLine("Enter the name of the meal:");

            string name = Console.ReadLine();

            MenuPoco item = _itemRepo.GetItemByName(name);

            if (item != null)
            {
                Console.WriteLine($"Name: {item.MealName}\n" +
                    $"Description: {item.MealDescription}\n" +
                    $"Number: {item.MealNumber}\n" +
                    $"Ingredients List: {item.IngredientsList}\n" +
                    $"Price: {item.MealPrice}");
            }
            else
            {
                    Console.WriteLine("No meal exists with that name");
            }
            
        }

        private void UpdateExistingItems()
        {
            ViewAllItems();

            Console.WriteLine("Please give the name of the meal to update");

            string oldName = Console.ReadLine();

            MenuPoco newItem = new MenuPoco();

            Console.WriteLine("Enter the item's name:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the item's number:");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);

            Console.WriteLine("Enter the item's description:");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the item's list of ingredients:");
            newItem.IngredientsList = Console.ReadLine();

            Console.WriteLine("Enter the item's price:");
            string mealPriceAsString = Console.ReadLine();
            newItem.MealPrice = double.Parse(mealPriceAsString);

            bool wasUpdated = _itemRepo.UpdateItemList(oldName, newItem);

            if (wasUpdated)
            {
                Console.WriteLine("Update successful!");
            }
            else
            {
                Console.WriteLine("Update was not successful...");
            }

        }

        private void DeleteExistingItems()
        {
            ViewAllItems();

            Console.WriteLine("Enter the name of item to be removed");

            string input = Console.ReadLine();

            bool wasDeleted = _itemRepo.RemoveItemFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted");
            }
            else
            {
                Console.WriteLine("The content could not be deleted");
            }
        }

    }
}
    

