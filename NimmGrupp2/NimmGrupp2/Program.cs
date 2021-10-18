using System;

namespace NimmGrupp2
{
    class Program
    {
        //Main method
        static void Main(string[] args)
        {
            bool x = true;
            
            
            //Game loop  
            while (x)
            {

                //x = false;
            }
            
        }

        void Draw()
        {
            
            
        }
    }

    public abstract class player
    {
        int score { get; set; }
        

    }

    //Human class, for more players
    public class Human : player
    {
        


    }

    public class EasyAI : player
    {



    }

    public class GamerModeAI : player
    {


    }

}
