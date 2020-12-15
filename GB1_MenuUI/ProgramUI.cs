using GB1_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB1_MenuUI
{
    public class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            SeedMenuList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1. Create new Menu Item\n" +
                    "2. List Menu Items\n" +
                    "3. Delete Menu Items\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        DisplayMenuList();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Sayonara!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a single number.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create new Menu Item
        private void CreateMenuItem()
        {
            Console.Clear();
            Menu newMenuItem = new Menu();

            Console.WriteLine("Enter the Menu Item Number:");
            string numberAsString = Console.ReadLine();
            newMenuItem.Number = int.Parse(numberAsString);

            Console.WriteLine("Enter the Menu Item Name");
            newMenuItem.Name = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the Description for the Item");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Add an ingredient:");
            newMenuItem.ListOfIngredients.Add(Console.ReadLine());
            bool stillAdding = true;
            while (stillAdding)
            {
            Console.WriteLine("Would you like add another ingredient?(y/n)");
            string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "y":
                        Console.WriteLine("Add an ingredient:");
                        newMenuItem.ListOfIngredients.Add(Console.ReadLine());
                        break;
                    case "n":
                        stillAdding = false;
                        break;
                }
               // took these two lines out because it caused extra prompts for "would you like to add an ingredient" to show up instead of moving on to the next property immediately
               // Console.WriteLine("Would you like add another ingredient?(y/n)");
               // input = Console.ReadLine();
            }

            Console.WriteLine("Enter the price for the menu item:");
            string priceAsString = Console.ReadLine();
            newMenuItem.Price = decimal.Parse(priceAsString);

            _menuRepo.AddMenuItem(newMenuItem);
        }

        //view the menu list
        private void DisplayMenuList()
        {
            Console.Clear();

            List<Menu> listOfMenuItems = _menuRepo.GetMenuList();

            foreach (Menu menu in listOfMenuItems)
            {
                Console.WriteLine($"Menu Number: {menu.Number}\n" +
                    $"Name: {menu.Name}\n" +
                    $"Description: {menu.Description}\n" +
                    $"Price: ${menu.Price}");
                Console.WriteLine("List of ingredients:");
                foreach (var item in menu.ListOfIngredients)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n");
            }
        }

        //delete menu items
        private void DeleteMenuItem()
        {
            DisplayMenuList();

            Console.WriteLine("\nEnter the name of the menu item you would like to remove.");

            string input = Console.ReadLine();

            bool wasDeleted = _menuRepo.DeleteMenuItem(input);

            if (wasDeleted)
            {
                Console.WriteLine("The item was deleted.");
            }
            else
            {
                Console.WriteLine("The item was not deleted.");
            }
        }

        //seed method
        private void SeedMenuList()
        {
            Menu pasta = new Menu(1, "Pasta", "Pasta with meatballs", new List<string> { "Noodles", "Marinara", "Meatballs" }, 4.99m);
            Menu chicken = new Menu(2, "Chicken", "Fried Chicken with fries", new List<string> { "Chicken", "Fries" }, 6.53m);

            _menuRepo.AddMenuItem(pasta);
            _menuRepo.AddMenuItem(chicken);
        }
    }
}
