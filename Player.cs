using System;
using System.Collections.Generic;

namespace NimmGrupp2
{
    // Cointains logic and variables for players and AIs
    public abstract class Player
    {
        public int score = 0;
        public string name;
        
        public abstract Tuple<int, int> play(int[] board);
    }

    //Human class, for more players
    public class Human : Player
    {
        public Human(string aname)
        {
            name = aname;
        }        
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
                    throw new UserInputException();
                }
                else if (s1 > 2 || s1 < 0) 
                { 
                    throw new UserInputException();
                }
                else if (board[s1] < s2)
                {
                    throw new UserInputException();
                }
                else { x = false; }
            }
            var t1 = Tuple.Create(s1, s2);
            return t1;
        }
    }

    public class EasyAI : Player
    {

        public EasyAI()
        {
            name = "Greggie, eater of cupcakes";
        }
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
        public GamerModeAI()
        {
            name = "Harambe, we still remeber";
        }
        
        public override Tuple<int, int> play(int[] board)
        {
            string[] board2 = new string[] { "", "", "" };
            int[] drag = new int[] { 0, 0, 0 };
            int sum = 0;


            for (int i = 0; i <= board.Length - 1; i++)
            {
                board2[i] = Convert.ToString(board[i], 2);
                board[i] = Convert.ToInt32(board2[i]);
            }

            // 101 101 101
            for (int j = 0; j <= board.Length - 1; j++)
            {
                sum += board[j];
            }
            // 303

            char[] siffror = sum.ToString().ToCharArray();
            // 3 0 3

            if (siffror[0] % 2 != 0)
            {
                Console.WriteLine(siffror[0]);
                drag[0] = 1;
            }
            if (siffror[1] % 2 != 0)
            {
                Console.WriteLine(siffror[1]);
                drag[1] = 1;
            }
            if (siffror[2] % 2 != 0)
            {
                Console.WriteLine(siffror[2]);
                drag[2] = 1;
            }

            String tempor = "";
            foreach(int i in drag)
            {
                tempor += Convert.ToString(i);
            }

            int output = Convert.ToInt32(tempor, 2);

            var tuppel = Tuple.Create(0, output);

            return tuppel;
        }
    }
}