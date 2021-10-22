using System;
using System.Collections.Generic;

namespace NimmGrupp2
{
    public abstract class Player
    {
        public int score;

        public abstract Tuple<int, int> play(int[] board);
    }

    //Human class, for more players
    public class Human : Player
    {
        //tillfällig metod
        public override Tuple<int, int> play(int[] board)
        {
            throw new NotImplementedException();
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
            Tuple<int, int> t1 = new Tuple<int, int>(item1, item2);
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