using Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Badges_Repository_Tests
{
    [TestClass]
    public class BadgesRepoTests
    {
        //Declare fields, for use elsewhere
        private BadgesRepo _repo;
        private BadgesPoco _badges;

        //Quasi Helper Method
        [TestInitialize]
        public void GetThisPartyStarted()
        {
            _repo = new BadgesRepo();
            _badges = new BadgesPoco(1150, new List<string>() { "A1" });

            _repo.AddNewBadge(_badges);
        }

        //Test the Create
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {

        }
    }
}
