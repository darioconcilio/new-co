using System;
using System.Net.Http;

namespace NewCo.ApiTest
{
    class Program
    {
        static string BaseUrl { get; set; }

        static void Main(string[] args)
        {
            BaseUrl = @"https://localhost:44301/";

            TestItemGet();
        }

        static void SetColor(ConsoleColor foregroud, ConsoleColor background)
        {
            Console.ForegroundColor = foregroud;
            Console.BackgroundColor = background;
        }

        static void TestItemGet()
        {
            var title = "Item Get";
            var result = "OK";

            SetColor(ConsoleColor.White, ConsoleColor.Blue);
            Console.WriteLine($"START {title}");

            Console.ResetColor();

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri(BaseUrl);
            string response = hc.GetStringAsync(@"api/items").Result;

            //var items = JsonConvert


            SetColor(ConsoleColor.White, ConsoleColor.Blue);
            Console.WriteLine($"END {title}: {result}");
        }
    }
}
