using System;

namespace NimmGrupp2
{
    public class Running
    {
        public void RunningFunc()
        {
            //Pre game settings
            EasyAI aI = new EasyAI();
            GameLogic gL = new GameLogic();
            bool turn1 = true;
            int[] newBoard = gL.Board();
            foreach (int item in newBoard)
                    {
                        Console.WriteLine(item);
                    }           
                    
                    Drawer.DrawBoard(newBoard);

            //Person's turn
            while(turn1)
            {
                int s1, s2;
                char[] splitChars = new[] {','};
                string playerInput = Console.ReadLine();
                string[] inputData = playerInput.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

                if(inputData.Length != 2)
                {
                    Console.WriteLine("Only the format 'integer,integer' is allowed!");
                }
                else
                {   
                    Int32.TryParse(inputData[0], out s1);     
                    Int32.TryParse(inputData[1], out s2);                
                    var t1 = Tuple.Create(s1, s2);
                }

                turn1 = false;
            }
            //Other person / AI's turn
            while(!turn1)
            {
                Tuple<int, int> t2 = aI.play(newBoard);
            }

        }
    }
}