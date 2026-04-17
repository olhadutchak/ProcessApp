using System;
using System.Threading;

namespace ChildProcessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;

            Console.WriteLine("Child process started...");

            while (true)
            {
                counter++;
                Console.WriteLine($"Counter: {counter}");

                Thread.Sleep(1000);
            }
        }
    }
}
