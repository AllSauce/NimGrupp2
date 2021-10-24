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
                Tuple<int, int> t1 = player1.play(gL.GetBoard());
                gL.RemoveSticks(t1);
                gL.GameOver(turn1, player1, player2);
                turn1 = false;
            }

            
            //Other person / AI's turn
            while (turn1 == false)
            {
                
                Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, null);
                Tuple<int, int> t2 = player2.play(gL.GetBoard());
                gL.RemoveSticks(t2);
                gL.GameOver(turn1, player1, player2);
                turn1 = true;
            }

            
        }
    }
}