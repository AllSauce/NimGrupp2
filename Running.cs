using System;

namespace NimmGrupp2
{
    public class Running
    {
        GameLogic gL;
        bool turn1 = true;
        Tuple<int, int> t1 = Tuple.Create(0, 0);
        Tuple<int, int> t2 = Tuple.Create(0, 0);        
        // Constructor
        public Running()
        {
            gL = new GameLogic();            
        }

        public void RunningFunc(Player player1, Player player2)
        {
                                  
            //First person's turn
            while(turn1)
            {
                if (gL.GetBoard()[0] == 5 && gL.GetBoard()[1] == 5 && gL.GetBoard()[2] == 5)
                {
                    Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, null);
                }
                else
                {
                    //Skapar en ny int då tuple är readonly och 
                    int tempdisplayer = t2.Item1 + 1;
                    Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, player2.name + " took " + t2.Item2 + " sticks from stack " + tempdisplayer);
                }            
                
                bool y = true;
                //Loops until valid input is given
                while(y)
                {
                    try
                    {
                        t1 = player1.play(gL.GetBoard());
                        break;
                    }
                    // Catches exceptions that are thrown due to player input error and repromts the user
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
                
                if (gL.GetBoard()[0] == 5 && gL.GetBoard()[1] == 5 && gL.GetBoard()[2] == 5)
                {
                    Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, null);
                }
                else
                {
                    int tempdisplayer = t1.Item1 + 1;
                    Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, player1.name + " took " + t1.Item2 + " sticks from stack " + tempdisplayer);
                }                               
               
                bool x = true;
                //Loops until valid input is given
                while (x)
                {
                    try 
                    {
                        t2 = player2.play(gL.GetBoard());
                        break;
                    }
                    // Catches exceptions that are thrown due to player input error and repromts the user
                    catch( UserInputException)
                    {
                        Drawer.DrawGameUI(gL.GetBoard(), turn1, player1, player2, "Please enter valid input!");
                    }
                }
                //Removes sticks                
                gL.RemoveSticks(t2);
                //Checks if game is over
                gL.GameOver(turn1, player1, player2);
                turn1 = true;
            }            
        }
    }
}