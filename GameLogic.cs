using System;
using System.Collections.Generic;

 namespace NimmGrupp2
 {
    public class GameLogic
    {
        //Sets board:
        //Index represents the stack
        //Number at index is the amount of sticks in respective stack
        private int[] board = {5, 5, 5};    
        // Getter for board                   
        public int[] GetBoard()
        {
           return board;
        }
        // Removes sticks from board based on index and amount
        public void RemoveSticks(Tuple<int, int> input)
        {
                //Chosen stack 
                int stack = input.Item1;
                //Chosen amount of sticks to remove
                int amount = input.Item2;

                //Replaces old value with new value
                board[stack] = board[stack] - amount;
        }
        // checks if game is over and adds score. Doesn't reset whose turn it is so that losing player starts next game
        public void GameOver(bool player1Turn, Player player1, Player player2)
        {
            if(player1Turn && board[0] == 0 && board[1] == 0 && board[2] == 0)
            {
                player1.score++;
                //Draws Winning message
                Drawer.DrawGameUI(board, player1Turn, player1, player2, player1.name +" Wins! Tap enter to play again!");
                Console.ReadLine();
                //Resets board
                board[0] = 5;
                board[1] = 5;
                board[2] = 5;

            }
            else if(!player1Turn && board[0] == 0 && board[1] == 0 && board[2] == 0)
            {
                player2.score++;
                //Draws winning message
                Drawer.DrawGameUI(board, player1Turn, player1, player2, player2.name +" Wins! Tap enter to play again!");
                Console.ReadLine();
                //Resets Board
                board[0] = 5;
                board[1] = 5;
                board[2] = 5;

            }
        }
    }
 }