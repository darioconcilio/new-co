using System;
using System.Globalization;

namespace TestGlobalization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            #region simple example

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Current culture");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.DisplayName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Setting current culture");

            CultureInfo italianCultureInfo = new CultureInfo("de-DE");
            CultureInfo.CurrentCulture = italianCultureInfo;
            CultureInfo.CurrentUICulture = italianCultureInfo;

            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.DisplayName);

            Console.ResetColor();
            Console.ReadLine();

            //return;

            #endregion

            #region change culture

            Console.WriteLine("Change culture\n");
            Console.WriteLine($"Cultura\t\tValuta\t\tData");
         

            Console.ForegroundColor = ConsoleColor.Green;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            CurrencyTest();

            Console.ForegroundColor = ConsoleColor.Yellow;
            CultureInfo.CurrentCulture = new CultureInfo("it-IT");
            CurrencyTest();

            Console.ForegroundColor = ConsoleColor.Red;
            CultureInfo.CurrentCulture = new CultureInfo("de-DE");
            CurrencyTest();

            Console.ResetColor();
            Console.ReadLine();

            #endregion
        }

        static void CurrencyTest()
        {
            Console.Write($"{CultureInfo.CurrentCulture.Name}\t\t");

            string priceAsString = "50.99";
            string cultureCode = "en-US";
            decimal price = decimal.Parse(priceAsString, new CultureInfo(cultureCode)) + 1;
            Console.Write($"{price:C}");

            string dateAsString = "25/08/2022";
            cultureCode = "it-IT";

            DateTime date = DateTime.Parse(dateAsString, new CultureInfo(cultureCode));
            Console.WriteLine($"\t\t{date:D}");
        }
    }
}
