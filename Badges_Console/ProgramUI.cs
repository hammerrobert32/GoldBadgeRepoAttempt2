using Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    class ProgramUI
    {
        public BadgesRepo _badgesRepo = new BadgesRepo();

        public void Run()
        {
            SeedQueue();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.Write("Ich wunsche Ihnen einen schonen tag!\n");
                        keepRunning = false;
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewBadge()
        {
            Console.Clear();
            BadgesPoco newBadge = new BadgesPoco();

            Console.WriteLine("What is the number on the badge?:");
            string badgeIdAsString = Console.ReadLine();
            newBadge.BadgeId = int.Parse(badgeIdAsString);

            Console.WriteLine("List a door that it needs access to:");
            newBadge.Badge = Console.ReadLine();

            Console.WriteLine("Any other doors (y/n)?:");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                Console.WriteLine("List a door that it needs access to:");
                newBadge.Badge = Console.ReadLine();
            }
            else if (input == "n")
            {
                Menu();
            }
            else
            {
                Console.Write("Please use y/n...");
            }

        }

        private bool EditBadge()
        {
            Console.Clear();
            var newBadge = new BadgesPoco();
            Console.WriteLine("What is the badge number to update?:");
            string _badgeNumberAsString = Console.ReadLine();
            var badgeNumber = int.Parse(_badgeNumberAsString);
            var badgeToUpdate = _badgesRepo.GetBadgeByKey(badgeNumber);
            Console.WriteLine("What would you like to do?:\n" +
                "1. Remove a door\n" +
                "2.Add a door");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Which door to remove?");
                    string doorRemove = Console.ReadLine();
                    _badgesRepo.EditBadge(int badgeNumber, BadgesPoco doorRemove);
                    break;
                case "2":
                    Console.WriteLine("Which door to add?");
                    string doorAdd = Console.ReadLine();
                    _badgesRepo.EditBadge(int badgeNumberTwo, BadgesPoco doorAdd);
                    break;
            }
        }

        private void ListAllBadges()
        {
            Console.Clear();
            _badgesRepo.ViewAllBadges();
        }

        private void SeedDictionary()
        {
            BadgesPoco badgeOne = new BadgesPoco(12345, new List<string>() { "A7" });
            BadgesPoco badgeTwo = new BadgesPoco(22345, new List<string>() { "A1", "A4", "B1", "B2" });
            BadgesPoco badgeThree = new BadgesPoco(32345, new List<string>() { "A4", "A5" });

        }
    }
}
