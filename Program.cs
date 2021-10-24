using System;
using System.Collections;
using System.Collections.Generic;

namespace NimmGrupp2
{
    class Program
    {
        //Main method
        static void Main(string[] args)
        {
            Intro f = new Intro();                        
            Running roon = new Running();
            bool x = true;
            Console.ForegroundColor = ConsoleColor.Green;
            // Plays intro screen                                  
            var players = f.firstOfAll();
            //Game loop  
            while (x)
            {
                roon.RunningFunc(players.Item1, players.Item2);
            }
        }
    }
    // Exception to handle user input error in Human.play method
    public class UserInputException : System.Exception
    {
        public UserInputException() { }
        public UserInputException(string message) : base(message) { }
        public UserInputException(string message, System.Exception inner) : base(message, inner) { }
        protected UserInputException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}