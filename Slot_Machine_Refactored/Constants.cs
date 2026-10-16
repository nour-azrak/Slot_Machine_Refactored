using System;
using System.Collections.Generic;
using System.Text;

namespace Slot_Machine_Refactored
{
    internal class Constants
    {
        public const int    // General game configuration 
                            // Game costs and wins
                            STARTING_AMOUNT = 3,
                            WINNING_COMBINATION_AMOUNT = 4,
                            COST_PER_ROUND = 1,
                            MULTIPLE_ALL_ROWS = 3,

                            // Game modes
                            MIDDLE_ROW_MODE = 1,
                            ALL_ROWS_MODE = 2,
                            ALL_COLUMS_MODE = 3,
                            ALL_DIAGONALS_MODE = 4,
                            QUIT_GAME = 5,
                            SLEEP_DURATION_BEFORE_NEXT_ROUND = 5000,

                            //Narrow window of max min is used
                            // to increase the probability of winning row, column or diagonal.
                            MAX_RANDOM_NUMBER = 3,
                            MIN_RANDOM_NUMBER = 1,

                            FIRST_ARRAY_POSITION = 0,

                            ARRAY_DIMENTION_SIZE = 3;
    }
}
