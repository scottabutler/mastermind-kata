using System;
using System.Collections.Generic;

namespace Mastermind.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var secret = new List<char>{'a', 'b', 'c', 'd'};
            Console.WriteLine(Core.Eval(secret: secret, new List<char>{'a', 'b', 'c', 'd'}).AsString());
            Console.WriteLine(Core.Eval(secret: secret, new List<char>{'b', 'b', 'c', 'd'}).AsString());
            Console.WriteLine(Core.Eval(secret: secret, new List<char>{'b', 'a', 'c', 'd'}).AsString());
            Console.WriteLine(Core.Eval(secret: new List<char>{'b', 'b', 'c', 'd'}, new List<char>{'a', 'c', 'b', 'd'}).AsString());
        }
    }
}
