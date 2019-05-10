using System;
using FileLogger;
using System.Diagnostics.CodeAnalysis;

namespace ReversePolishCalculator
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var rpnEngine = new RpnEngine();
            var log = new Logger(eLogLevel.Debug);
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter a valid RPN string to be calculated:");
                    string input = Console.ReadLine();
                    
                    Console.WriteLine(rpnEngine.CalculateRpn(input));

                    Console.WriteLine("Another? (y/n)");
                    var response = Console.ReadLine();
                    if (response == "n" || response == "N")
                    { break; }
                }
                catch (Exception ex)
                {
                    var message = $"Caught exception running.  Message was {ex.Message}.  Don't do that!";
                    log.Fatal(message);
                    Console.WriteLine(message);
                }
            }
        }
    }
}
