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
            while (true)
            {
                try
                {
                    Console.WriteLine("Tere, tahad mängida? Siis sisesta 1");

                    if (int.TryParse(Console.ReadLine(), out int vastus))
                    {
                        if (vastus == 1)
                        {
                            Console.Clear();
                            StartGame.Start();
                        }
                        else
                        {
                            Console.WriteLine("Ei taha siis ei taha");
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vale sisend!");
                        Thread.Sleep(2000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Tekkis viga: " + ex.Message);
                }
            }
        }
    }
}