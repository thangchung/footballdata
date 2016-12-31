using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using CiK.FootballData;

namespace ConsoleSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IFootballDataClient client1 = new FootballDataClient(Protocol.HTTP, "acec24061235402a802ad04c9f7b6b81");
            var watch1 = Stopwatch.StartNew();

            Console.WriteLine("Run with Reactive...");

            var competitionsStream =
                client1.GetSeasonsStream("2016")
                    .SelectMany(x => x.ToArray())
                    .Where(x => x.League == "PL")
                    .Do(_ => Console.WriteLine("Only lazy evaluation."));

            competitionsStream.Subscribe(
                pl => { Console.WriteLine($"OnNext: {pl.Caption}."); },
                ex => Console.WriteLine($"OnError: {ex.Message}."),
                () =>
                {
                    Console.WriteLine("OnCompleted.");

                    watch1.Stop();
                    Console.WriteLine($"{watch1.ElapsedMilliseconds}ms");
                }
            );

            Console.ReadKey();

            IFootballDataClient client2 = new FootballDataClient(Protocol.HTTP, "acec24061235402a802ad04c9f7b6b81");
            var watch2 = Stopwatch.StartNew();
            Console.WriteLine("Run with TPL...");

            var competitionsAsync = client2.GetSeasonsAsync("2016").Result;
            var firstCompetion = competitionsAsync.FirstOrDefault(x => x.League == "PL");
            Console.WriteLine($"Result: {firstCompetion.Caption}.");

            watch2.Stop();
            Console.WriteLine($"{watch2.ElapsedMilliseconds}ms");

            Console.ReadKey();
        }
    }
}