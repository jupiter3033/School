using System;
namespace SportOrganizer
{
	public class TUI
	{
        public static void PrintMainMenu()
        {
            Console.WriteLine("┌───────────────────────────┐");
            Console.WriteLine("│                           │");
            Console.WriteLine("│   1.dodaj gracza          │");
            Console.WriteLine("│   2.usuń gracza           │");
            Console.WriteLine("│   3.pokaż liste meczów    │");
            Console.WriteLine("│   4.dodaj zespół          │");
            Console.WriteLine("│   5.usuń zespół           │");
            Console.WriteLine("│   6.stwórz mecz           │");
            Console.WriteLine("│   7.edytuj mecz           │");
            Console.WriteLine("│   8.zapisz                │");
            Console.WriteLine("│   9.wczytaj               │");
            Console.WriteLine("│   10.zakończ              │");
            Console.WriteLine("│   11.show all             │");
            Console.WriteLine("│   12.clear screen         │");
            Console.WriteLine("│                           │");
            Console.WriteLine("└───────────────────────────┘");
            Console.WriteLine("Wybierz opcje:");
        }
    }
}

