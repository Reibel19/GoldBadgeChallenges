using System;
using System.Collections.Generic;
using GB1_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GB1_MenuTests
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepo _repo;
        private Menu _menu;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _menu = new Menu(1, "Pasta", "Pasta with meatballs", new List<string> { "Noodles", "Marinara", "Meatballs" }, 4.99m);

            _repo.AddMenuItem(_menu);
        }

        //add method
        [TestMethod]
        public void AddMenuItem_ShouldGetNotNull()
        {
            //arrange
            Menu menu = new Menu();
            menu.Name = "Pasta";
            MenuRepo repo = new MenuRepo();

            //act
            repo.AddMenuItem(menu);
            Menu menuFromDirectory = repo.GetMenuItemByName("Pasta");


            //assert
            Assert.IsNotNull(menuFromDirectory);
        }

        //delete
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //arrange

            //act
            bool deleteMenuItem = _repo.DeleteMenuItem(_menu.Name);

            //assert
            Assert.IsTrue(deleteMenuItem);
        }
    }
}
