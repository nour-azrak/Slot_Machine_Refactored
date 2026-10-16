using System;
using System.Collections.Generic;
using System.Text;

namespace Slot_Machine_Refactored
{
    internal class Logic
    {
        static Random random = new Random();

        static public int[,] FillSlotMachineArray(int [,] slotMachineArray)
        {
            
            for (int rows = 0; rows < slotMachineArray.GetLength(0); rows++)
            {
                for (int cols = 0; cols < slotMachineArray.GetLength(1); cols++)
                {
                    slotMachineArray[rows, cols] = random.Next(Constants.MIN_RANDOM_NUMBER, Constants.MAX_RANDOM_NUMBER);
                }
            }

            return slotMachineArray;
        }

        static public bool CheckWinningMiddleRow(int[,] slotMachineArray, int middleRowPosition)
        {
            int[] trackWinningRow = new int[slotMachineArray.GetLength(1)];
            bool middleRowIsEqual = true;
            for (int col = 0; col < slotMachineArray.GetLength(1); col++)
            {
                trackWinningRow[col] = slotMachineArray[middleRowPosition, col];
                if (trackWinningRow[col] != trackWinningRow[Constants.FIRST_ARRAY_POSITION])
                {
                    middleRowIsEqual = false;
                }
            }
            return middleRowIsEqual;
            
        }

        static public bool CheckAnyWinningRow(int[,] slotMachineArray)
        {
            int[] trackWinningRow = new int[slotMachineArray.GetLength(0)];
            bool rowIsEqual = true;
            for (int row = 0; row < slotMachineArray.GetLength(0); row++)
            {
                rowIsEqual = true;
                for (int col = 0; col < slotMachineArray.GetLength(1); col++)
                {
                    trackWinningRow[col] = slotMachineArray[row, col];
                    if (trackWinningRow[col] != trackWinningRow[Constants.FIRST_ARRAY_POSITION])
                    {
                        rowIsEqual = false;
                    }
                }
                if (rowIsEqual) break;
            }
            return rowIsEqual;
        }

        static public bool CheckAnyWinningCol(int[,] slotMachineArray)
        {
            int[] trackWinningColumn = new int[slotMachineArray.GetLength(0)];
            bool colIsEqual = true;
            for (int row = 0; row < slotMachineArray.GetLength(0); row++)
            {
                colIsEqual = true;
                for (int col = 0; col < slotMachineArray.GetLength(1); col++)
                {
                    trackWinningColumn[col] = slotMachineArray[col, row];
                    if (trackWinningColumn[col] != trackWinningColumn[Constants.FIRST_ARRAY_POSITION])
                    {
                        colIsEqual = false;
                    }
                }
                if (colIsEqual) break;
            }
            return colIsEqual;
        }

        static public bool CheckAnyWinningDiagonal (int[,] slotMachineArray)
        {
            int[] trackWinningDiagonalOne = new int[slotMachineArray.GetLength(0)];
            int[] trackWinningDiagonalTwo = new int[slotMachineArray.GetLength(0)];
            bool diagOneIsEqual = true;
            bool diagTwoIsEqual = true;
            for (int row = 0; row < slotMachineArray.GetLength(0); row++)
            {
                diagOneIsEqual = true;
                diagTwoIsEqual = true;
                for (int col = 0; col < slotMachineArray.GetLength(1); col++)
                {
                    if (col == row)
                    {
                        trackWinningDiagonalOne[col] = slotMachineArray[col, row];

                    }
                    if (trackWinningDiagonalOne[col] != trackWinningDiagonalOne[Constants.FIRST_ARRAY_POSITION])
                    {
                        diagOneIsEqual = false;
                    }
                    if (col == slotMachineArray.GetLength(1) - 1 - row)
                    {
                        trackWinningDiagonalTwo[col] = slotMachineArray[col, row];

                    }
                    if (trackWinningDiagonalTwo[col] != trackWinningDiagonalTwo[Constants.FIRST_ARRAY_POSITION])
                    {
                        diagTwoIsEqual = false;
                    }

                }
                if (diagOneIsEqual || diagTwoIsEqual) break;
            }
            return (diagOneIsEqual || diagTwoIsEqual);
        }

        /// <summary>
        /// this fuction has 2 modes.
        /// If the user is inputting additional money, it 
        /// simply adds the sum to current money.
        /// Otherwise, winning sum is added to
        /// current money
        /// </summary>
        /// <param name="userMode"></param>
        /// <param name="currentMoney"></param>
        /// <param name="userWon"></param>
        /// <param name="userInputMode"></param>
        /// <param name="moneyUserInput"></param>
        /// <returns></returns>
        static public int CalculateCurrentBalance(int userMode, int currentMoney, bool userWon, bool userInputMode, int moneyUserInput)
        {
            if (userInputMode) return currentMoney += moneyUserInput;
            if (userMode == Constants.MIDDLE_ROW_MODE || userMode == Constants.ALL_DIAGONALS_MODE)
            {
                currentMoney -= Constants.COST_PER_ROUND;
            }
            else
            {
                currentMoney -= Constants.COST_PER_ROUND * Constants.MULTIPLE_ALL_ROWS;
            }
            if (userWon) currentMoney += Constants.WINNING_COMBINATION_AMOUNT;


            return currentMoney;
        }

        static public int CheckValidArrayDimention (int[,] slotMachineArray, out bool validArray)
        {
            int middleRowPosition = 1;
            validArray = true;
            if (Constants.ARRAY_DIMENTION_SIZE % 2 != 0 && Constants.ARRAY_DIMENTION_SIZE % 2 != 0)
            {
                middleRowPosition = (Constants.ARRAY_DIMENTION_SIZE - 1) / 2;
            }
            else
            {
                validArray = false;
            }

            return middleRowPosition;
        }
    }
}
