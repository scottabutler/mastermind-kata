using System;
using System.Collections.Generic;

namespace Mastermind.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var secret = new List<Colours>{Colours.Blue, Colours.Green, Colours.Red, Colours.Orange};
            Console.WriteLine(Core.Eval(secret: secret, new List<Colours>{Colours.Blue, Colours.Green, Colours.Red, Colours.Orange}).AsString());
            Console.WriteLine(Core.Eval(secret: secret, new List<Colours>{Colours.Green, Colours.Yellow, Colours.Green, Colours.Yellow}).AsString());
            Console.WriteLine(Core.Eval(secret: secret, new List<Colours>{Colours.Green, Colours.Green, Colours.Red, Colours.Orange}).AsString());
            Console.WriteLine(Core.Eval(secret: secret, new List<Colours>{Colours.Green, Colours.Blue, Colours.Red, Colours.Orange}).AsString());
            Console.WriteLine(Core.Eval(secret: new List<Colours>{Colours.Green, Colours.Green, Colours.Red, Colours.Orange}, new List<Colours>{Colours.Blue, Colours.Red, Colours.Green, Colours.Orange}).AsString());
        }
    }
}
