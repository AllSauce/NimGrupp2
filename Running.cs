using System;

namespace NimmGrupp2
{
    public class Running
    {
        GameLogic gL;
        bool turn1 = true;
        

        public Running()
        {

            gL = new GameLogic();
            
        }

        public void RunningFunc(Player player1, Player player2)
        {
            
            

            //Draws/updates the board (redundant due to drawer class)
            //foreach (int item in gL.GetBoard())
            //{
            //    Console.WriteLine(item);
            //}           
                    
            

            //First person's turn
            while(turn1)
            {
                
                Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, null);
                bool y = true;
                Tuple<int, int> t1 = Tuple.Create(0, 0);
                while(y)
                {
                    try
                    {
                        t1 = player2.play(gL.GetBoard());
                        break;
                    }
                    catch(UserInputException)
                    {
                         Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, "Please enter valid input!");               
                    }

                }
                
                gL.RemoveSticks(t1);
                gL.GameOver(turn1, player1, player2);
                turn1 = false;

            }

            
            //Other person / AI's turn
            while (turn1 == false)
            {
                
                Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, null);
                bool x = true;
                Tuple<int, int> t2 = Tuple.Create(0, 0);
                while (x)
                {
                    try 
                    {
                        t2 = player2.play(gL.GetBoard());
                        break;
                    }
                    catch( UserInputException)
                    {
                        Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, "Please enter valid input!");
                    }
                }
                
                gL.RemoveSticks(t2);
                gL.GameOver(turn1, player1, player2);
                turn1 = true;
            }

            
        }
    }
}