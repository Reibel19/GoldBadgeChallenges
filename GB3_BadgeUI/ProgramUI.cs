using GB3_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB3_BadgeUI
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Badge\n" +
                    "2. View All Badges\n" +
                    "3. Update Door Access for a Badge\n" +
                    "4. Clear all Door Access for a Badge\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        DisplayAllBadges();
                        break;
                    case "3":
                        UpdateBadge();
                        break;
                    case "4":
                        ClearDoorAccess();
                        break;
                    case "5":
                        Console.WriteLine("See you later alligator!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        //create
        private void CreateNewBadge()
        {
            Badge newBadge = new Badge();

            Console.WriteLine("Enter the BadgeID:");
            string badgeIDstring = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeIDstring);

            Console.WriteLine("Add Door Access:");
            newBadge.ListOfDoorAccess.Add(Console.ReadLine());
            bool keepAdding = true;
            while (keepAdding)
            {
                Console.WriteLine("Would you like to add another Door Access? (y/n)");
                string input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "y":
                        Console.WriteLine("Add Door Access:");
                        newBadge.ListOfDoorAccess.Add(Console.ReadLine());
                        break;
                    case "n":
                        keepAdding = false;
                        break;
                    }
            }

            _badgeRepo.AddNewBadge(newBadge);
        }

        //display, how to display horizontal lists
        private void DisplayAllBadges()
        {
            Console.Clear();

            Dictionary<int, Badge> dictionary = _badgeRepo.GetDictionary();

            Console.WriteLine("BadgeID:\tDoor Access:\t");

            foreach (KeyValuePair<int, Badge> badge in dictionary)
            {
                Console.Write($"{badge.Key,-10}\t");

                foreach (var item in badge.Value.ListOfDoorAccess)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }

        }

        //update
        private void UpdateBadge()
        {
            DisplayAllBadges();

            

            Console.WriteLine("\nEnter the Badge ID that you'd like to update:");
            int badgeID = int.Parse(Console.ReadLine());

            Badge oldbadge = _badgeRepo.GetBadgeByID(badgeID);

            Console.WriteLine("What would you like to do?\n" +
                "1. Add Door Access\n" +
                "2. Remove Door Access");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Add Door Access:");
                    string addDoor = Console.ReadLine();
                    _badgeRepo.AddUpdateMeth(badgeID, addDoor);
                    bool keepAdding = true;
                    while (keepAdding)
                    {
                        Console.WriteLine("Would you like to add another Door Access? (y/n)");
                        string inputDoor = Console.ReadLine();
                        switch (inputDoor.ToLower())
                        {
                            case "y":
                                Console.WriteLine("Add Door Access:");
                                string addDoors = Console.ReadLine();
                                _badgeRepo.AddUpdateMeth(badgeID, addDoors);
                                Console.WriteLine("Door Access Added.");
                                break;
                            case "n":
                                keepAdding = false;
                                break;
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Remove Door Access:");
                    string removeDoor = Console.ReadLine();
                    _badgeRepo.RemoveUpdateMeth(badgeID, removeDoor);
                    bool keepRemoving = true;
                    while (keepRemoving)
                    {
                        Console.WriteLine("Would you like to remove another Door Access? (y/n)");
                        string outputDoor = Console.ReadLine();
                        switch (outputDoor.ToLower())
                        {
                            case "y":
                                Console.WriteLine("Remove Door Access:");
                                string removeDoors = Console.ReadLine();
                                _badgeRepo.RemoveUpdateMeth(badgeID, removeDoors);
                                Console.WriteLine("Door was Removed.");
                                break;
                            case "n":
                                keepRemoving = false;
                                break;
                        }
                    }
                    break;
            }
            

        }

        //clear door access
        private void ClearDoorAccess()
        {
            DisplayAllBadges();

            Console.WriteLine("\nEnter the BadgeID you would like to clear access:");
            int badgeID = int.Parse(Console.ReadLine());

            bool wasCleared = _badgeRepo.ClearDoorAccess(badgeID);
            if (wasCleared)
            {
                Console.WriteLine("The Door Access was successfully cleared.");
            }
            else
            {
                Console.WriteLine("The Door Access was not cleared.");
            }

        }

        private void SeedBadgeDictionary()
        {
            Badge badge1 = new Badge(12345, new List<string> { "A7" });
            Badge badge2 = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge badge3 = new Badge(32345, new List<string> { "A4", "A5" });

            _badgeRepo.AddNewBadge(badge1);
            _badgeRepo.AddNewBadge(badge2);
            _badgeRepo.AddNewBadge(badge3);
        }
    }
}
