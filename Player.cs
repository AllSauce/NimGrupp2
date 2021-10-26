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
                //Looks for any Userinput errors
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
            name = "Greggie eater of cupcakes";
        }
        
        //Easy AI spelningsmetod
        public override Tuple<int, int> play(int[] board)
        {
            
           Random random = new Random();
           
           List<Tuple<int, int>> legalMoves = new List<Tuple<int, int>>();
            for (int i = 0; i < 3; i++)
            {
                for(int x = 0; x < board[i]; x++)
                {
                    legalMoves.Add(Tuple.Create(i, x + 1));
                }
            }
            return legalMoves[random.Next(0, legalMoves.Count - 1)];           
        }
    }
    // AI with perfect strategy
    public class GamerModeAI : Player
    {
        //EasyAI tempEz = new EasyAI();
        
        
        public GamerModeAI()
        {
            name = "Harambe, we still remeber";
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static List<Tuple<int, int>> Getlegalmoves(int[] board)
        {
            List<Tuple<int, int>> legalMoves = new List<Tuple<int, int>>();
            for (int i = 0; i < 3; i++)
            {
                for(int x = 0; x < board[i]; x++)
                {
                    legalMoves.Add(Tuple.Create(i, x + 1));
                }
            }
            return legalMoves;
        }
        private static int GetNimSum(int[] board)
        {
            //Creates new board separeate from main game board
            int[] tempboard = new int[3];
            Array.Copy(board, tempboard, board.Length);
            
            int[] sums = new int[3];
            string[] boardString = new string[board.Length];
            //Creates a binary representation of the board
            //Each string in boardstring represetns one stack
            for (int i = 0; i <= board.Length - 1; i++)
            {
                boardString[i] = Convert.ToString(board[i], 2);                
            }
            //reverses all strings in boardstrings for easier binary readability
            for(int i = 0; i < boardString.Length; i++)
            {
                boardString[i] = Reverse(boardString[i]);
            }
            //Counts the amount of ones, twos and fours in the binary numbers
            foreach (string number in boardString)
            {
                char[] numbs = number.ToCharArray();
                int i = 0;
                foreach(char num in numbs)
                {
                    if (num == '1')
                    {
                        sums[i]++;
                    }
                    i++;
                }
            }
            // Checks for doubles of same number as they cancel eachother out
            for(int i = 0; i < sums.Length; i++)
            {
                var x = true;
                while (x)
                {
                    if (sums[i] >= 2)
                    {
                        sums[i]--;
                        sums[i]--;
                    }
                    else { break; }
                }
            }
            int nimsumm = 0;
            //Counts the nimsum based on sums
            for (int i = 0; i < sums.Length; i++)
            {
                if (sums[i] > 0)
                {
                    switch (i)
                    {
                        case 0:
                            nimsumm = nimsumm + 4;                           
                            break;
                        case 1:
                            nimsumm = nimsumm + 2;
                            break;
                        case 2:
                            nimsumm++;
                            break;
                        default:
                            break;
                    }                        
                }
            }
            return nimsumm;
        }
        public override Tuple<int, int> play(int[] board)
        {
            List<Tuple<int, int>> legalMoves = Getlegalmoves(board); 
            //looks for a move that will result in a losing board for opponent
            foreach (Tuple<int, int> move in legalMoves)
            {
                int[] tempboard = new int[board.Length];
                Array.Copy(board, tempboard, board.Length);
                tempboard[move.Item1] = tempboard[move.Item1] - move.Item2;
                //Nimsum is 0 when board is losing
                if (GetNimSum(tempboard) == 0)
                {
                    return move;
                }
            }
            // Returns a random move if no winning move is found
            Random random = new Random();
            return legalMoves[random.Next(0, legalMoves.Count - 1)];
        }

        /*private int choose_stack(int[] board)
        {
            int temp = 0;
            int index = 0;

            for(int i = 0; i < board.Length; i++)
            {
                if(temp < board[i])
                {
                    temp = board[i];
                    index = i;
                }
            }
            return index;
        }*/

        /*static bool PerfektBoard(int[] x, int y, int z)
        {
            int[] tempArr = new int[3];
            Array.Copy(tempArr, x, 3);
                
            int summan = 0;
            string[] boarden2 = new string[] { "", "", "" };

            for (int i = 0; i <= tempArr.Length - 1; i++)
            {
                boarden2[i] = Convert.ToString(tempArr[i], 2);
                tempArr[i] = Convert.ToInt32(boarden2[i]);
                summan += tempArr[i];
            }

            char[] siffror = summan.ToString().ToCharArray();

            for(int i = 0; i < siffror.Length; i++)
            {
                if(siffror[i] % 2 != 0)
                {
                    return false;
                }
            }

            return true;
        }*/
        
        /*public override Tuple<int, int> play(int[] board)
        {
            //Instantiate
            int[] tempArr = new int[3];
            Array.Copy(tempArr, board, 3);
            string[] board2 = new string[] { "", "", "" };
            int[] drag = new int[] { 0, 0, 0 };
            int sum = 0;
            int stack = 0;

            //Converts to binary string
            for (int i = 0; i <= tempArr.Length - 1; i++)
            {
                board2[i] = Convert.ToString(tempArr[i], 2);
                tempArr[i] = Convert.ToInt32(board2[i]);
            }

            // 303
            //Sum of binary numbers 101 101 101
            for (int j = 0; j <= board.Length - 1; j++)
            {
                sum += tempArr[j];
            }

            //Splits the integer
            char[] siffror = sum.ToString().ToCharArray();
            // 3 0 3
            
            //Checks if even
            bool work = false;
            for(int i = 0; i < siffror.Length; i++)
            {
                if(siffror[i] % 2 != 0)
                {
                    drag[i] = 1;
                    work = true;
                }
            }

            //Converts it back to be usable
            int output = convBack(drag);

            //Choose correct stack
            for(int i = 0; i < 3; i++)
            {
                if(PerfektBoard(tempArr, output, i))
                {
                    stack = i + 1;
                }
            }

            var tuppel = Tuple.Create(stack, output);

            if(work == false)
            {
                return tempEz.play(board);
            }
        
            return tuppel;

        }*/

        /*private int convBack(int[] x)
        {
            String tempor = "";
            foreach(int i in x)
            {
                tempor += Convert.ToString(i);
            }

            int temp = Convert.ToInt32(tempor, 2);

            return temp;
        }*/
    }
}