using GoldBadgeConsoleAppChallenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cafe_Unit_Test
{
    [TestClass]
    public class MenuRepoTests
    {
        //Declare fields, for use elsewhere
        private MenuRepo _repo;
        private MenuPoco _item;

        //Quasi Helper Method
        [TestInitialize]
        public void GetThisPartyStarted()
        {
            _repo = new MenuRepo();
            _item = new MenuPoco(1,"Pig's feet", "Braised with pig's blood, and served with a side of roasted pig testicles and boiled intestines, it's sure to delight!", "Feet, eyes, intestines", 11.50);

            _repo.AddItemToList(_item);
        }

        //Test the Create
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange   
            MenuPoco item = new MenuPoco();                                             //new up
            item.MealName = "Anchovie Icecream";                                        //set
            MenuRepo repo = new MenuRepo();                                             //new up

            //Act
            repo.AddItemToList(item);                                                   //add
            MenuPoco itemFromDirectory = repo.GetItemByName("Anchovie Icecream");       //get

            //Assert
            Assert.IsNotNull(itemFromDirectory);                                        //verify
        }

        //Test the Update  
        [TestMethod]
        public void UpdateItem_ShouldReturnTrue()
        {
            //Arrange  ...(Test Init)
            MenuPoco newItem = new MenuPoco(1, "Pig's feet", "Braised with pig's blood, and served with a side of toasted pig eyeballs (seasonal), it's sure to delight!", "ingredients", 11.50);

            //Act
            bool updateOutput = _repo.UpdateItemList("Pig's feet", newItem);

            //Assert
            Assert.IsTrue(updateOutput);
        }

        //Test the Delete  
        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            //Arrange  ...(Test Init)

            //Act
            bool deleteOutput = _repo.RemoveItemFromList(_item.MealName);

            //Assert
            Assert.IsTrue(deleteOutput);
        }

    }
}
