using System;

namespace Client
{
    class Program
    {
        private static bool _isRunning = true;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Dad Joke");
                Console.WriteLine("2. Web API Message");
                ConsoleKeyInfo input = Console.ReadKey();
                string output = input.Key switch
                {
                    ConsoleKey.D0 => Exit(),
                    ConsoleKey.D1 => GetDadJoke(),
                    ConsoleKey.D2 => GetApiMessage(),
                    _ => "Not supported"
                };
                Console.WriteLine();
                Console.WriteLine(output);
                Console.ReadKey();
            } while (_isRunning);
        }

        public static string Exit()
        {
            _isRunning = false;
            return "Bye";
        }

        public static string GetDadJoke()
        {
            return WebUtils.GetAsyncText("https://icanhazdadjoke.com/").Result;
        }

        public static string GetApiMessage()
        {
            return WebUtils.GetAsyncText("https://localhost:44368/Message").Result;
        }
    }
}
