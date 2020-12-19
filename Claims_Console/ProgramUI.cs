using Claims_Repository;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    class ProgramUI
    {
        public ClaimsRepo _claimsRepo = new ClaimsRepo();

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
                Console.WriteLine("Make a selection:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        HandleNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        Console.Write("Haben Sie einen guten Tag!\n");
                        keepRunning = false;
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewAllClaims()
        {
            Console.Clear();

            Queue<ClaimsPoco> claimsQ = _claimsRepo.ViewClaimsQueue();

            foreach (ClaimsPoco claim in claimsQ)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimId}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: ${claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"Is Valid: {claim.IsValid}\n");
            }
        }

        private void HandleNextClaim()
        {
            Console.Clear();

            Queue<ClaimsPoco> claimQ = _claimsRepo.ViewClaimsQueue();

            ClaimsPoco peekedClaim = claimQ.Peek();

            Console.WriteLine($"Claim ID: {peekedClaim.ClaimId}\n" +
                    $"Claim Type: {peekedClaim.ClaimType}\n" +
                    $"Description: {peekedClaim.Description}\n" +
                    $"Claim Amount: ${peekedClaim.ClaimAmount}\n" +
                    $"Date of Incident: {peekedClaim.DateOfIncident}\n" +
                    $"Date of Claim: {peekedClaim.DateOfClaim}\n" +
                    $"Is Valid: {peekedClaim.IsValid}\n");

            Console.WriteLine("\nWould you like to continue with this claim? (y/n)");

            string input = Console.ReadLine().ToLower();

            Console.Clear();

            if (input == "y")
            {
                ClaimsPoco pulledClaim = claimQ.Dequeue();

                Console.WriteLine($"Claim ID: {pulledClaim.ClaimId}\n" +
                    $"Claim Type: {pulledClaim.ClaimType}\n" +
                    $"Description: {pulledClaim.Description}\n" +
                    $"Claim Amount: ${pulledClaim.ClaimAmount}\n" +
                    $"Date of Incident: {pulledClaim.DateOfIncident}\n" +
                    $"Date of Claim: {pulledClaim.DateOfClaim}\n" +
                    $"Is Valid: {pulledClaim.IsValid}\n");

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

        private void AddNewClaim()
        {
            Console.Clear();
            ClaimsPoco newClaim = new ClaimsPoco();

            Console.Write("Enter the Claim ID:");
            string claimIdAsString = Console.ReadLine();
            newClaim.ClaimId = int.Parse(claimIdAsString);

            Console.Write("Enter the Claim Type (Car, Home, Theft):");
            newClaim.ClaimType = Console.ReadLine();

            Console.Write("Enter the Description:");
            newClaim.Description = Console.ReadLine();

            Console.Write("Enter the Claim Amount:");
            string claimAmount = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(claimAmount);

            Console.Write("Enter Date of Incident (Format of YYYY/MM/DD):");
            string incidentDate = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDate);

            Console.Write("Enter Date of Claim (Format of YYYY/MM/DD):");
            string claimDate = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDate);

            Console.Write("Is this claim valid? (y/n):");
            string input = Console.ReadLine().ToLower();
            if (input == "y") 
            {
                newClaim.IsValid = true;
            }
            else if (input == "n")
            {
                newClaim.IsValid = false;
            }
            else
            {
                Console.Write("Please use y/n...");
            }

            _claimsRepo.AddClaimsQueue(newClaim);


        }

        private void SeedQueue()
        {
            ClaimsPoco claimOne = new ClaimsPoco(1, "Car", "Car accident on 465", 400, Convert.ToDateTime("2018/04/25"), Convert.ToDateTime("2018/04/27"), true);
            ClaimsPoco claimTwo = new ClaimsPoco(2, "Home", "House fire in kitchen", 4000, Convert.ToDateTime("2018/04/11"), Convert.ToDateTime("2018/04/12"), true);
            ClaimsPoco claimThree = new ClaimsPoco(3, "Theft", "Stolen Pancakes", 4, Convert.ToDateTime("2018/04/27"), Convert.ToDateTime("2018/06/01"), false);

            _claimsRepo.AddClaimsQueue(claimOne);
            _claimsRepo.AddClaimsQueue(claimTwo);
            _claimsRepo.AddClaimsQueue(claimThree);

        }
    }
}
