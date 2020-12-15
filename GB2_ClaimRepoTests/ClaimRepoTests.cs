using System;
using System.Collections.Generic;
using GB2_ClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GB2_ClaimRepoTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepo _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            _claim = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);

            _repo.AddClaimToQueue(_claim);
        }


        //add method
        [TestMethod]
        public void AddToQueue_ShouldNotNull()
        {
            //arrange
            Claim claim = new Claim();
            claim.ClaimID = 1;
            ClaimRepo repo = new ClaimRepo();

            //act
            repo.AddClaimToQueue(claim);
            Queue<Claim> claimInQueue = repo.GetClaimQueue();

            //Assert
            Assert.IsNotNull(claimInQueue);

        }




        //delete method
        [TestMethod]
        public void DeleteTopClaimInQueue_ShouldReturnTrue()
        {
            //arrange
            Claim claim = new Claim();
            claim.ClaimID = 1;
            ClaimRepo repo = new ClaimRepo();

            //act
            repo.AddClaimToQueue(claim);
            //using test initializer data prior to delete
            //bool deleteResult = _repo.DequeueClaim();  this is the exact same, good habit to do both
            bool deleteResult = repo.DequeueClaim();

            //assert
            Assert.IsTrue(deleteResult);
        }

    }
}
