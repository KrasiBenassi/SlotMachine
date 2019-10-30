using SlotMachine.Common.Models;
using System;
using System.Collections.Generic;

namespace SlotMachine
{
    public class UserInteractions : IUserInteractions
    {
        public decimal RequestDeposit()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            
            decimal deposit;
            bool isDepositValid = decimal.TryParse(Console.ReadLine(), out deposit);

            while (!isDepositValid || deposit <= 0)
            {
                Console.WriteLine("The value you have entered is not valid.");
                isDepositValid = decimal.TryParse(Console.ReadLine(), out deposit);
            }

            return deposit;
        }

        public decimal RequestBet()
        {
            Console.WriteLine("Enter stake amount:");
            
            decimal amount;
            bool isAmountValid = decimal.TryParse(Console.ReadLine(), out amount);

            while (!isAmountValid || amount <= 0)
            {
                Console.WriteLine("The amount is not a valid number.");
                isAmountValid = decimal.TryParse(Console.ReadLine(), out amount);
            }

            return amount;
        }

        public bool RequestNewGame()
        {
            Console.WriteLine("You spend all you money. Do you want to play again... (y/n)");
            var playerResponse = Console.ReadLine();

            if (string.Equals(playerResponse, "y"))
            {
                return true;
            }
            else if (string.Equals(playerResponse, "n"))
            {
                return false;
            }

            RequestNewGame();

            return false;
;        }

        public void DrawBord(List<List<Symbol>> symbolsGrid)
        {
            foreach (var symbolsRow in symbolsGrid)
            {
                Console.WriteLine(string.Join(", ", symbolsRow));
            }
        }
    }
}
