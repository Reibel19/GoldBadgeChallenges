using GB2_ClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB2_ClaimUI
{
    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            SeedClaimQueue();
            MenuUI();
        }

        private void MenuUI()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option\n" +
                    "1. Add a Claim to the Queue\n" +
                    "2. View the Claims Queue\n" +
                    "3. Take care of a Claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewClaim();
                        break;
                    case "2":
                        DisplayClaimQueue();
                        break;
                    case "3":
                        DeleteClaimInQueue();
                        break;
                    case "4":
                        Console.WriteLine("See you later!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid number then press ENTER");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }


        }


        //add to queue
        private void AddNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.WriteLine("Enter the Claim ID number:");
            string idAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(idAsString);

            Console.WriteLine("Enter the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaim.TypeOfClaim = (ClaimType)typeAsInt;

            Console.WriteLine("Enter the description for the claim:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the claim amount:");
            string amountAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(amountAsString);

            Console.WriteLine("Enter the date of the incident: (yyyy/mm/dd)");
            string incidentDateString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDateString);

            Console.WriteLine("Enter the date the claim was placed: (yyyy/mm/dd)");
            string claimDateString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDateString);

            Console.WriteLine("Is this claim valid? (y/n)");
            string validAsString = Console.ReadLine().ToLower();
            if (validAsString == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimRepo.AddClaimToQueue(newClaim);
        }

        //view current queue
        private void DisplayClaimQueue()
        {
            Console.Clear();
            Queue<Claim> claimQueue = _claimRepo.GetClaimQueue();
            foreach (Claim claim in claimQueue)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: ${claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident.ToShortDateString()}\n" +    //to short date string takes the time off when displayed
                    $"Date of Claim: {claim.DateOfClaim.ToShortDateString()}\n" +
                    $"Is Claim Valid: {claim.IsValid}\n");
            }
        }

        //remove from queue
        private void DeleteClaimInQueue()
        {
            DisplayClaimQueue();

            Console.WriteLine("\nWould you like to take care of the claim at the front of the queue? (y/n)");
            //Console.ReadLine();

            //bool wasDeleted = _claimRepo.DequeueClaim();

            if (Console.ReadLine().ToLower() == "y")
            {
                _claimRepo.DequeueClaim();
                Console.WriteLine("The claim was taken care of.");
            }
            else
            {
                Console.WriteLine("The claim was not taken care of.");
            }

        }

        //seed queue
        private void SeedClaimQueue()
        {
            Claim accident = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018,04,25), new DateTime(2018,04,27), true);
            Claim houseFire = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            Claim thievery = new Claim(3, ClaimType.Theft, "Stolen Pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _claimRepo.AddClaimToQueue(accident);
            _claimRepo.AddClaimToQueue(houseFire);
            _claimRepo.AddClaimToQueue(thievery);

        }

    }
}
