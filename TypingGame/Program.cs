using System;
using System.Collections.Generic;
using System.Linq;

namespace TypingGame
{
    class Program
    {
        private static string _usage = "./TypingGame [-l | -w]\r\n\r\n    -l  letters\r\n    -w  words";
        private static List<string> _letters = "ABCDEFGHIJKLMNOPQRSTUBWXYZ"
            .ToCharArray().ToList()
            .Select(c => c.ToString()).ToList();

        static void Main(string[] args)
        {
            var random = new Random();
            var setting = "l";

            if (args.Length > 2)
            {
                Console.WriteLine(_usage);
            }
            else if (args.Length == 0)
            {
                setting = GetSetting();
                if (setting == "q")
                {
                    return;
                }
            }
            else
            {
                setting = args[0];
            }

            var index = random.Next(_letters.Count);
            var done = false;

            while (true)
            {
                // print the next letter
                index = random.Next(_letters.Count);
                Console.Write($"  {_letters[index]}");

                done = false;

                while (!done)
                {
                    Console.Write(" ");
                    var i = Console.ReadKey(true).Key.ToString();
                    if (i == "Escape")
                    {
                        return;
                    }
                    if (i == _letters[index])
                    {
                        Console.Write(i);
                        done = true;
                    }
                }
                Console.WriteLine();
            }
        }

        static string GetSetting()
        {
            while (true)
            {
                Console.Write("Type \"l\" for letters and \"w\" for words (or \"exit\"): ");
                var i = Console.ReadLine();
                if (i == "l" || i == "w" || i == "q")
                {
                    return i;
                }
            }
        }
    }
}
