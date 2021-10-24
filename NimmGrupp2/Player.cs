using System;
using System.Collections.Generic;

namespace NimmGrupp2
{
    public abstract class Player
    {
        public int score = 0;

        public abstract Tuple<int, int> play(int[] board);
    }

    //Human class, for more players
    public class Human : Player
    {
        //tillfällig metod
        public override Tuple<int, int> play(int[] board)
        {
            
            bool x = true;
            int s1 = 0, s2 = 0;
            char[] splitChars = new[] { ',' };
            string playerInput;
            string[] inputData;
            bool test1;
            bool test2;
            while (x)
            {
                
                
                playerInput = Console.ReadLine();
                inputData = playerInput.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

                //Tuple to return
                try
                {
                    test1 = Int32.TryParse(inputData[0], out s1);
                    test2 = Int32.TryParse(inputData[1], out s2);
                }
                catch 
                { 
                    test1 = false; test2 = false; 
                }
                
                //Converts to indexposition
                
                s1--;
                if (!test1 || !test2)
                {
                    Console.WriteLine("Please Eneter valid input!");
                }
                else if (s1 > 2 || s1 < 0) 
                { 
                    Console.WriteLine("Please Eneter valid input!"); 
                }
                else if (board[s1] < s2)
                {
                    Console.WriteLine("Please enter valid input!");
                }
                else { x = false; }

            }
            var t1 = Tuple.Create(s1, s2);
            return t1;
        }
    }

    public class EasyAI : Player
    {
        //tillfällig metod
        public override Tuple<int, int> play(int[] board)
        {
            
            Random random = new Random();
           
           List<int> list = new List<int>();
           //kollar efter tomma högar
           for (int i = 0; i < board.Length; i++)
           {
               if (board[i] != 0)
               {
                  list.Add(i); 
               }
           }
           //slumpar en av högarna som inte är tom
            int item1 = list[random.Next(0, list.Count - 1)];
            //slumpar antalet stickor som den ska ta
            int item2 = random.Next(1, board[item1]);
            var t1 = Tuple.Create(item1, item2);
            return t1;
           
        }
    }

    public class GamerModeAI : Player
    {
        //tillfällig metod
        public override Tuple<int, int> play(int[] board)
        {
            throw new NotImplementedException();
        }
    }
}