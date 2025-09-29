using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;


namespace Manu_Uus
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "";  // Имя игрока доступно во всех ветках меню

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Tere tulemast mängu!");
                    Console.WriteLine("1 - Alusta mängu (Tavaline keerukus)");
                    Console.WriteLine("2 - Vaata edetabelit");
                    Console.WriteLine("3 - Valida keerukus");
                    Console.WriteLine("0 - Välju");
                    Console.Write("Valik: ");

                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.Write("Sisesta oma nimi: ");
                        userName = Console.ReadLine();
                        Console.Clear();

                        int finalScore = StartGame.Start(userName); // передаём имя
                        Leaderboard.SaveScore(userName, finalScore);

                        Console.WriteLine("Tulemus salvestatud!");
                        Console.WriteLine("\nVajuta suvalist klahvi, et naasta menüüsse...");
                        Console.ReadKey(true);
                    }
                    else if (input == "2")
                    {
                        Console.Clear();
                        Leaderboard.ShowLeaderboard();
                        Console.WriteLine("\nVajuta suvalist klahvi, et naasta menüüsse...");
                        Console.ReadKey(true);
                    }
                    else if (input == "3")
                    {
                        if (string.IsNullOrEmpty(userName))
                        {
                            Console.Write("Palun sisesta oma nimi enne keerukuse valikut: ");
                            userName = Console.ReadLine();
                        }

                        Console.Clear();
                        Console.WriteLine("Kerge - K");
                        Console.WriteLine("Tavaline keerukus - M");
                        Console.WriteLine("Raske - R");
                        Console.WriteLine("Demon - D");
                        Console.Write("Valik: ");

                        string keerukus = Console.ReadLine().ToUpper();

                        int finalScore = Keerukus.MääraKeerukus(keerukus, userName);
                        if (finalScore > 0)
                        {
                            Leaderboard.SaveScore(userName, finalScore);
                            Console.WriteLine("Tulemus salvestatud!");
                        }

                        Console.WriteLine("\nVajuta suvalist klahvi, et naasta menüüsse...");
                        Console.ReadKey(true);
                    }
                    else if (input == "0")
                    {
                        break; // выход из программы
                    }
                    else
                    {
                        Console.WriteLine("Vale valik!");
                        Thread.Sleep(1500);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Tekkis viga: " + ex.Message);
                    Console.WriteLine("\nVajuta suvalist klahvi, et naasta menüüsse...");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
