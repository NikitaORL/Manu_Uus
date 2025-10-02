using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manu_Uus
{
    public static class SnakeSkin
    {
        public static char ChooseSkin()
        {
            Console.Clear();
            Console.WriteLine("Vali oma ussi välimus (skin):");
            Console.WriteLine("1 - ● (klassikaline)");
            Console.WriteLine("2 - ■ (ruudukene)");
            Console.WriteLine("3 - * (täheke)");
            Console.WriteLine("4 - o (ringike)");
            Console.Write("Valik: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1": return '●';
                case "2": return '■';
                case "3": return '*';
                case "4": return 'o';
                default: return '●'; // стандартный скин
            }
        }
    }
}