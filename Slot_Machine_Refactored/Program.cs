namespace Slot_Machine_Refactored
{
    internal class Program
    {
        static void Main(string[] args)
        {

           // money
            int currentMoney = 0, moneyUserInput;

            // variable decleration for user mode selection
            int userSelection = 0;

            int variable = 32;
            // track whether the user has won
            bool userWon;

            int[,] slotMachineArray = new int[Constants.ARRAY_DIMENTION_SIZE, Constants.ARRAY_DIMENTION_SIZE];
            int middleRowPosition = Logic.CheckValidArrayDimention(slotMachineArray, out bool validArray);
            if (!validArray) UI.ThrowInvalidArrayException();

            UI.PrintWelcomeMessage();
            while (true)
            {
                userWon = false;
                while (true)
                {
                    if (!UI.GetValidUserInput(out moneyUserInput)) continue;
                    currentMoney = Logic.CalculateCurrentBalance(userSelection, currentMoney, userWon, Constants.USER_INPUT_MODE_ACTIVE, moneyUserInput);
                    if (!UI.CheckUserInputPlausibility(currentMoney)) continue;
                    break;
                }
                while (true)
                {
                    if (!UI.GetValidUserModeSelection(out userSelection)) continue;
                    break;
                }

                if (userSelection == 5) break;
                
                // fill with random numbers
                slotMachineArray = Logic.FillSlotMachineArray(slotMachineArray);

                // print slot machine.
                UI.PrintSlotMachineArray(slotMachineArray);

                Console.WriteLine();

                switch (userSelection)
                {
                    case 1:
                        // check if middle row has equal numbers
                        if (Logic.CheckWinningMiddleRow(slotMachineArray, middleRowPosition))
                        {
                            userWon = true;
                        }
                        break;

                    case 2:
                        // check if any row has equal numbers
                        if (Logic.CheckAnyWinningRow(slotMachineArray))
                        {
                            userWon = true;
                        }
                        break;

                    case 3:
                        // check if any columns has equal numbers
                        if (Logic.CheckAnyWinningCol(slotMachineArray))
                        {
                            userWon = true;
                        }

                        break;

                    case 4:
                        // check if any diagonal has equal numbers
                        if (Logic.CheckAnyWinningDiagonal(slotMachineArray))
                        {
                            userWon = true;
                        }
                        break;
                }
                // print user won or lost
                UI.PrintUserWin(userWon);

                // calculate current balance
                currentMoney = Logic.CalculateCurrentBalance(userSelection, currentMoney, userWon, Constants.USER_INPUT_MODE_INACTIVE, moneyUserInput);

                // print current balance
                UI.PrintCurrentBalance(currentMoney);

                // wait time to give player time before clearing the screen
                //Thread.Sleep(Constants.SLEEP_DURATION_BEFORE_NEXT_ROUND);
                //Console.Clear();
            }

        }
    }
}
