using System;
using System.Collections.Generic;
using System.Text;

namespace Slot_Machine_Refactored
{
    internal class UI
    {
        static public void PrintWelcomeMessage(int slotMachineDimention)
        {
            // welcome statement
            Console.WriteLine("Welcome to the slot machine");
            Console.WriteLine($"You have a {slotMachineDimention}x{slotMachineDimention} grid. If you hit a winning combination you win {Constants.WINNING_COMBINATION_AMOUNT} $\n");
            Console.WriteLine($"To start playing you need to enter {Constants.STARTING_AMOUNT} $. Each round costs at least {Constants.COST_PER_ROUND} $\n");
        }

        /// <summary>
        /// makes sure that user input is a whole positive integer or zero
        /// </summary>
        /// <param name="moneyUserInput"></param>
        /// <returns>validity information</returns>
        static public bool GetValidUserInput(out int moneyUserInput)
        {
            bool validUserInput;
            Console.Write("Please enter $ amount: ");
            validUserInput = int.TryParse(Console.ReadLine(), out moneyUserInput) && moneyUserInput >= 0;

            if (!validUserInput)
            {
                Console.WriteLine("Please enter a valid positive whole number. Zero is a valid input");
            }

            return validUserInput;

        }

        /// <summary>
        /// If current balance is less than Constants.STARTING_AMOUNT,
        /// the input is rejected
        /// </summary>
        /// <param name="currentMoney"></param>
        /// <returns></returns>
        static public bool CheckUserInputPlausibility(int currentMoney)
        {
            bool validUserInput = true;

            if (currentMoney < Constants.STARTING_AMOUNT)
            {
                Console.WriteLine($"Your current balance is {currentMoney} which is less than {Constants.STARTING_AMOUNT}. Please enter more $");
                validUserInput = false;
            }

            return validUserInput;
        }

        static public bool GetValidUserModeSelection(out int userSelection)
        {
            bool validUserInput;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("You can aim for the following combinations:");
            Console.WriteLine($"{Constants.MIDDLE_ROW_MODE}. The middle row (costs {Constants.COST_PER_ROUND} $)");
            Console.WriteLine($"{Constants.ALL_ROWS_MODE}. All rows (costs {Constants.COST_PER_ROUND * Constants.MULTIPLE_ALL_ROWS} $)");
            Console.WriteLine($"{Constants.ALL_COLUMS_MODE}. All column (costs {Constants.COST_PER_ROUND * Constants.MULTIPLE_ALL_ROWS} $)");
            Console.WriteLine($"{Constants.ALL_DIAGONALS_MODE}. Both Diagonals (costs {Constants.COST_PER_ROUND} $)");
            Console.WriteLine($"{Constants.QUIT_GAME}. Quit the game");
            Console.Write($"Please enter {Constants.MIDDLE_ROW_MODE}, {Constants.ALL_ROWS_MODE}, {Constants.ALL_COLUMS_MODE} or {Constants.ALL_DIAGONALS_MODE}: ");
            validUserInput = int.TryParse(Console.ReadLine(), out userSelection);
            if (!validUserInput || (userSelection != 1 && userSelection != 2 && userSelection != 3 && userSelection != 4 && userSelection != 5))
            {
                Console.WriteLine();
                Console.Write($"Please enter {Constants.MIDDLE_ROW_MODE}, {Constants.ALL_ROWS_MODE}, {Constants.ALL_COLUMS_MODE} or {Constants.ALL_DIAGONALS_MODE}: ");
                validUserInput = false;
            }
            return validUserInput;
        }

        static public void PrintSlotMachineArray(int[,] slotMachineArray)
        {
            for (int row = 0; row < slotMachineArray.GetLength(0); row++)
            {
                for (int col = 0; col < slotMachineArray.GetLength(1); col++)
                {
                    Console.Write($"{slotMachineArray[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static public void PrintUserWin(bool userWon)
        {
            if (userWon) Console.WriteLine("You won!");
            else Console.WriteLine("You lost!");
        }

        static public void PrintCurrentBalance(int currentMoney)
        {
            Console.WriteLine($"Your current balance is {currentMoney} $\n");
        }


        static public int GetValidSlotMachineDimention()
        {
            int slotMachineDimention = 3;
            bool validInput = false;
            Console.WriteLine("Dimention decleration might be invalid or implausible. The dimention must be an odd whole number above 0");

            while (!validInput)
            {
                Console.Write("Please input valid dimention for the slot machine:");
                validInput = int.TryParse(Console.ReadLine(), out slotMachineDimention) && slotMachineDimention > 0 && (slotMachineDimention % 2) == 1;
            }

            return slotMachineDimention;
        }
    }
}
