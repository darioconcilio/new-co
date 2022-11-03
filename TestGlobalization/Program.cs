using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestGlobalization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            #region simple example

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Current culture");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.DisplayName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Setting current culture");

            CultureInfo deCultureInfo = new CultureInfo("de-DE");
            CultureInfo.CurrentCulture = deCultureInfo;
            CultureInfo.CurrentUICulture = deCultureInfo;

            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.DisplayName);

            Console.ResetColor();
            Console.ReadLine();

            //return;

            #endregion

            #region change culture

            Console.WriteLine("Change culture\n");
            Console.WriteLine($"Culture\t\tCurrency\tDate");


            Console.ForegroundColor = ConsoleColor.Green;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            CurrencyTest();

            Console.ForegroundColor = ConsoleColor.Yellow;
            CultureInfo.CurrentCulture = new CultureInfo("it-IT");
            CurrencyTest();

            Console.ForegroundColor = ConsoleColor.Cyan;
            CultureInfo.CurrentCulture = new CultureInfo("de-DE");
            CurrencyTest();

            Console.ResetColor();
            Console.ReadLine();

            #endregion

            #region parent

            Console.ResetColor();
            Console.WriteLine("Current culture:");
            Console.ForegroundColor = ConsoleColor.Green;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            CultureInfo.CurrentUICulture = new CultureInfo("en-US");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.DisplayName);

            Console.ResetColor();
            Console.WriteLine("Relative Parent:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CultureInfo.CurrentCulture.Parent.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.Parent.DisplayName);

            Console.ResetColor();
            Console.WriteLine("\n\nCurrent culture:");
            Console.ForegroundColor = ConsoleColor.Blue;
            CultureInfo.CurrentCulture = new CultureInfo("en-GB");
            CultureInfo.CurrentUICulture = new CultureInfo("en-GB");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.DisplayName);

            Console.ResetColor();
            Console.WriteLine("Relative Parent:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CultureInfo.CurrentCulture.Parent.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.Parent.DisplayName);

            Console.ResetColor();
            Console.WriteLine("\n\nCurrent culture:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            CultureInfo.CurrentCulture = new CultureInfo("en-AU");
            CultureInfo.CurrentUICulture = new CultureInfo("en-AU");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.DisplayName);

            Console.ResetColor();
            Console.WriteLine("Relative Parent:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CultureInfo.CurrentCulture.Parent.Name);
            Console.WriteLine(CultureInfo.CurrentUICulture.Parent.DisplayName);

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
