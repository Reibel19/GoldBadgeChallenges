using System;
using System.Collections.Generic;
using GB3_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GB3_BadgeTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private BadgeRepo _repo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _badge = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });

            _repo.AddNewBadge(_badge);
        }

        //add
        [TestMethod]
        public void AddBadge_ShouldGetNotNull()
        {
            //arrange
            Badge badge = new Badge();
            badge.BadgeID = 22345;
            BadgeRepo repo = new BadgeRepo();

            //act
            repo.AddNewBadge(badge);
            Badge badgeFromDictionary = repo.GetBadgeByID(22345);

            //assert
            Assert.IsNotNull(badgeFromDictionary);
        }

        //update
        [TestMethod]
        public void UpdateAddDoor_ShouldReturnTrue()
        {
            //arrange
            Badge newBadge = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });

            //act
            bool updateResult = _repo.AddUpdateMeth(22345, "A27");

            //assert
            Assert.IsTrue(updateResult);
        }


        //update part 2 electric boogaloo
        [TestMethod]
        public void UpdateRemoveDoor_ShouldReturnTrue()
        {
            //arrange
            Badge newerBadge = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });

            //act
            bool updatedResult = _repo.RemoveUpdateMeth(22345, "A1");

            //assert
            Assert.IsTrue(updatedResult);
        }
        


        //delete
        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            //arrange
            Badge badge = new Badge();
            badge.BadgeID = 22345;
            BadgeRepo repo = new BadgeRepo();

            //act
            bool deleteResult = _repo.ClearDoorAccess(_badge.BadgeID);

            //assert
            Assert.IsTrue(deleteResult);
        }
    }
}
