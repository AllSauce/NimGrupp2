using System;
using System.Collections.Generic;

 namespace NimmGrupp2
 {
    public class GameLogic
        {
            //Sets board:
            //Index represents the stack
            //Number on index is the amount of sticks in respective stack
            private int[] board = {5, 5, 5};

            public int[] Board()
            {
                return board;
            }

            EasyAI player1 = new EasyAI();
            EasyAI player2 = new EasyAI();

            //Represents which players turn it is
            bool player1Turn = false;

            public void RemoveSticks(Tuple<int, int> input)
            {
                //Chosen stack 
                int stack = input.Item1;
                //Chosen amount of sticks to remove
                int amount = input.Item2;

                //Replaces old value with new value
                board[stack] = board[stack] - amount;
            }

            public void GameOver()
            {
                if(player1Turn && board[0] == 0 && board[1] == 0 && board[2] == 0)
                {
                    player2.score++;
                }
                else if(!player1Turn && board[0] == 0 && board[1] == 0 && board[2] == 0)
                {
                    player1.score++;
                }
            }
        }
}