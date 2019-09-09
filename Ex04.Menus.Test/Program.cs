using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            interfaceMenuTest();

            delegateMenuTest();
        }

        private static void interfaceMenuTest()
        {
            Interfaces.MainMenu firstMainMenu = new Interfaces.MainMenu("InterFace Main Menu");
            Interfaces.Menu dateTimeMenu = firstMainMenu.AddSubMenu("Show Data/Time");
            dateTimeMenu.AddOperation(new DateOperation(), "Show Date");
            dateTimeMenu.AddOperation(new TimeOperation(), "Show Time");

            Interfaces.Menu versionAndDigitsMenu = firstMainMenu.AddSubMenu("Version and Digits");
            versionAndDigitsMenu.AddOperation(new CountDigitsOperation(), "Count Didits");
            versionAndDigitsMenu.AddOperation(new ShowVersionOperation(), "Show Version");

            firstMainMenu.Show();
            Console.Clear();
        }

        private static void delegateMenuTest()
        {
            Delegates.MainMenu firstMainMenu = new Delegates.MainMenu("Delegate Main Menu");

            Delegates.Menu dateTimeMenu = firstMainMenu.AddSubMenuItem("Show Date/Time");
            Delegates.Menu versionAndDigitsMenu = firstMainMenu.AddSubMenuItem("Version and Digits");

            dateTimeMenu.AddActionMenuItem("Show Date", new DateOperation().Operate);
            dateTimeMenu.AddActionMenuItem("Show Time", new TimeOperation().Operate);
            versionAndDigitsMenu.AddActionMenuItem("Count Digits", new CountDigitsOperation().Operate);
            versionAndDigitsMenu.AddActionMenuItem("Show Version", new ShowVersionOperation().Operate);

            firstMainMenu.ShowMenu();
        }

        internal static void WriteAndClear(string i_string)
        {
            Console.Clear();
            Console.WriteLine(i_string);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static string getSentenceFromUser()
        {
            Console.WriteLine("Please Enter Sentece");

            return Console.ReadLine();
        }
    }
}
