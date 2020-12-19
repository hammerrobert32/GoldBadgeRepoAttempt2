using Claims_Repository;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Claims_Unit_Tests
{
    [TestClass]
    public class ClaimsRepoTests
    {
        private ClaimsRepo _repo;
        private ClaimsPoco _claim;

        [TestInitialize]
        public void GetThisPartyStarted()
        {
            _repo = new ClaimsRepo();
            _claim = new ClaimsPoco(4, "Car", "Wreck on I-70", 2000, Convert.ToDateTime("2018/04/27"), Convert.ToDateTime("2018/04/28"), true);

            _repo.AddClaimsQueue(_claim);
        }

        [TestMethod]
        public void AddClaimQueue_ShouldGetNotNull()
        {
            ClaimsPoco claim = new ClaimsPoco();
            claim.ClaimId = 3;
            ClaimsRepo repo = new ClaimsRepo();

            repo.AddClaimsQueue(claim);
            ClaimsPoco claimFromDirectory = repo.GetClaimById(3);

            Assert.IsNotNull(claimFromDirectory);
        }

        [TestMethod]
        public void ReadClaimsQ()
        {
            _repo.ViewClaimsQueue();
        }
    }
}
